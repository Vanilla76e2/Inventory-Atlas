using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Inventory_Atlas.Application.Services.Audit
{
    /// <summary>
    /// Сервис для логирования действий пользователей в системе.
    /// </summary>
    public class LogEntryService<T> : ILogEntryService<T>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;
        private readonly ILogEntryRepository _repo;
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// Создаёт экземпляр <see cref="LogEntryService"/>.
        /// </summary>
        /// <param name="uow">UnitOfWork для сохранения изменений.</param>
        /// <param name="logger">Системный логгер.</param>
        /// <param name="repo">Репозиторий логов.</param>
        /// <param name="httpContext">Доступ к текущему HttpContext для извлечения сессии пользователя.</param>
        public LogEntryService(IUnitOfWork uow, ILogger<LogEntryService<T>> logger, ILogEntryRepository repo, IHttpContextAccessor httpContext)
        {
            _uow = uow;
            _logger = logger;
            _repo = repo;
            _httpContext = httpContext;
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
                ActionTime = DateTime.UtcNow,
                Details = JsonSerializer.Serialize(details)
            };

            _repo.Add(entry);
            _logger.LogDebug("Log entry added successfully: {LogEntry}", entry);
        }

        /// <inheritdoc/>

        public async Task LogAndSaveAsync(ActionType action, int UserSessionId, CancellationToken ct = default)
        {
            _logger.LogDebug("Adding log entry: Action={Action}", action);
            var entry = new LogEntry
            {
                UserSessionId = UserSessionId,
                Action = action,
                ActionTime = DateTime.UtcNow
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
    }
}
