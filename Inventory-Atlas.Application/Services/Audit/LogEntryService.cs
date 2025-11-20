using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Services.Audit
{
    /// <summary>
    /// Сервис для логирования действий пользователей в системе.
    /// </summary>
    public class LogEntryService : ILogEntryService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<LogEntryService> _logger;
        private readonly ILogEntryRepository _repo;
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// Создаёт экземпляр <see cref="LogEntryService"/>.
        /// </summary>
        /// <param name="uow">UnitOfWork для сохранения изменений.</param>
        /// <param name="logger">Системный логгер.</param>
        /// <param name="repo">Репозиторий логов.</param>
        /// <param name="httpContext">Доступ к текущему HttpContext для извлечения сессии пользователя.</param>
        public LogEntryService(IUnitOfWork uow, ILogger<LogEntryService> logger, ILogEntryRepository repo, IHttpContextAccessor httpContext)
        {
            _uow = uow;
            _logger = logger;
            _repo = repo;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Асинхронно добавляет запись лога для текущей сессии в контекст.
        /// </summary>
        /// <param name="action">Тип действия пользователя.</param>
        /// <param name="details">Описание действия.</param>
        /// <param name="ct">Токен отмены операции.</param>
        public async Task LogAsync(ActionType action, string? details, CancellationToken ct = default)
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
                Details = details
            };

            await _repo.AddAsync(entry, ct);
            _logger.LogDebug("Log entry added successfully: {LogEntry}", entry);
        }

        public async Task LogLoginAsync(ActionType action, int UserSessionId, CancellationToken ct = default)
        {
            _logger.LogDebug("Adding log entry: Action={Action}", action);
            var entry = new LogEntry
            {
                UserSessionId = UserSessionId,
                Action = action,
                ActionTime = DateTime.UtcNow
            };

            await _repo.AddAsync(entry, ct);
            _logger.LogDebug("Log entry added successfully: {LogEntry}", entry);
            await _uow.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Асинхронно добавляет запись лога в контекст и сразу сохраняет изменения в базе.
        /// Используется для критичных действий, которые нельзя потерять.
        /// </summary>
        /// <param name="action">Тип действия пользователя.</param>
        /// <param name="details">Описание действия.</param>
        /// <param name="ct">Токен отмены операции.</param>
        public async Task LogAndSaveAsync(ActionType action, string? details, CancellationToken ct = default)
        {
            await LogAsync(action, details, ct);
            await _uow.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Получает все записи логов.
        /// </summary>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Список всех записей логов.</returns>
        public async Task<IReadOnlyList<LogEntry>> GetAllAsync(CancellationToken ct = default)
        {
            return await _repo.GetAllAsync(ct);
        }

        /// <summary>
        /// Получает записи логов по идентификатору сессии пользователя.
        /// </summary>
        /// <param name="userSessionId">Идентификатор сессии пользователя.</param>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Список записей логов для указанной сессии.</returns>
        public async Task<IReadOnlyList<LogEntry>> GetByUserAsync(int userSessionId, CancellationToken ct = default)
        {
            return await _repo.GetBySessionAsync(userSessionId, ct);
        }

        /// <summary>
        /// Получает записи логов по типу действия.
        /// </summary>
        /// <param name="action">Тип действия пользователя.</param>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Список записей логов с указанным типом действия.</returns>
        public async Task<IReadOnlyList<LogEntry>> GetByActionAsync(ActionType action, CancellationToken ct = default)
        {
            return await _repo.GetByActionType(action, ct);
        }

        /// <summary>
        /// Получает записи логов за указанный период времени.
        /// </summary>
        /// <param name="from">Начало периода (включительно).</param>
        /// <param name="to">Конец периода (включительно).</param>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Список записей логов за указанный период.</returns>
        public async Task<IReadOnlyList<LogEntry>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
        {
            return await _repo.GetByDateRangeAsync(from, to, ct);
        }
    }
}
