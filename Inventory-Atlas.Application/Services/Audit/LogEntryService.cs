using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace Inventory_Atlas.Application.Services.Audit
{
    /// <summary>
    /// Сервис для логирования действий пользователей в системе.
    /// </summary>
    public class LogEntryService<T> : ILogEntryService<T>
        where T : AuditableEntity
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;
        private readonly ILogEntryRepository _repo;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IDatabaseRepository<T> _dbRepo;

        /// <summary>
        /// Создаёт экземпляр <see cref="LogEntryService"/>.
        /// </summary>
        /// <param name="uow">UnitOfWork для сохранения изменений.</param>
        /// <param name="logger">Системный логгер.</param>
        /// <param name="repo">Репозиторий логов.</param>
        /// <param name="httpContext">Доступ к текущему HttpContext для извлечения сессии пользователя.</param>
        public LogEntryService(IUnitOfWork uow, ILogger<LogEntryService<T>> logger, 
                               ILogEntryRepository repo, IHttpContextAccessor httpContext,
                               IDatabaseRepository<T> dbRepo)
        {
            _uow = uow;
            _logger = logger;
            _repo = repo;
            _httpContext = httpContext;
            _dbRepo = dbRepo;
        }

        /// <inheritdoc/>
        public void Log(ActionType action, LogDetails<T>? details)
        {
            _logger.LogDebug("Adding log entry: Action={Action}, Details={Details}", action, details);

            var session = _httpContext.HttpContext?.Items["Session"] as UserSession;
            if (session == null)
            {
                _logger.LogWarning("Cannot log action '{Action}' because UserSession is missing in HttpContext.Items.", action);
                return;
            }

            var entry = new LogEntry
            {
                UserSessionId = session.Id,
                Action = action,
                Details = JsonSerializer.Serialize(details)
            };

            _repo.Add(entry);
            _logger.LogDebug("Log entry added successfully: {LogEntry}", entry);
        }

        /// <inheritdoc/>

        public async Task LogAuthAndSaveAsync(ActionType action, int UserSessionId, CancellationToken ct = default)
        {
            _logger.LogDebug("Adding log entry: Action={Action}", action);
            var entry = new LogEntry
            {
                UserSessionId = UserSessionId,
                Action = action
            };

            _repo.Add(entry);
            _logger.LogDebug("Log entry added successfully: {LogEntry}", entry);
            await _uow.SaveChangesAsync(ct);
        }

        /// <inheritdoc/>

        public async Task LogAndSaveAsync(ActionType action, LogDetails<T>? details, CancellationToken ct = default)
        {
            Log(action, details);
            await _uow.SaveChangesAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<T?> SaveEntityWithLogAsync(T entity, ActionType action,
                                                    LogDetails<T>? details = null,
                                                    CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to save {Entity} with log.", typeof(T));

                await _uow.BeginTransactionAsync(ct);

                _dbRepo.Add(entity);

                await _uow.SaveChangesAsync(ct);

                Log(action, details ?? new LogDetails<T> { New = entity });

                await _uow.SaveChangesAsync(ct);
                _logger.LogDebug("{Entity} successfuly saved with log", typeof(T));

                _logger.LogDebug("Commiting changes ...");
                await _uow.CommitAsync();
                _logger.LogDebug("Changes commited succesfully.");

                return entity;
            }
            catch
            {
                _logger.LogError("Saving {Entity} with log failed. Rolling back.", typeof(T));
                await _uow.RollbackAsync();
                throw;
            }
        }

        /// <inheritdoc/>

        public async Task<IReadOnlyList<LogEntry>> GetAllAsync(CancellationToken ct = default)
        {
            return await _repo.GetAllAsync(ct);
        }

        /// <inheritdoc/>

        public async Task<IReadOnlyList<LogEntry>> GetByUserAsync(int userSessionId, CancellationToken ct = default)
        {
            return await _repo.GetBySessionAsync(userSessionId, ct);
        }

        /// <inheritdoc/>

        public async Task<IReadOnlyList<LogEntry>> GetByActionAsync(ActionType action, CancellationToken ct = default)
        {
            return await _repo.GetByActionType(action, ct);
        }

        /// <inheritdoc/>

        public async Task<IReadOnlyList<LogEntry>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
        {
            return await _repo.GetByDateRangeAsync(from, to, ct);
        }

        public LogDetails<T> CreateDetailsForUpdate(T oldEntity, T newEntity)
        {
            var details = new LogDetails<T>();
            details.Old = new Dictionary<string, object>();
            details.New = new Dictionary<string, object>();

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p => p.CanRead && p.CanWrite);

            foreach (var prop in props)
            {
                var oldValue = prop.GetValue(oldEntity);
                var newValue = prop.GetValue(newEntity);

                if (!Equals(oldValue, newValue))
                {
                    details.Old[prop.Name] = oldValue;
                    details.New[prop.Name] = newValue;
                }
            }

            return details;
        }
    }
}
