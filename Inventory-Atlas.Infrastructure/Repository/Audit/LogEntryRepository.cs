using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Audit
{
    /// <summary>
    /// Репозиторий для работы с записями лога действий пользователя.
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{LogEntry}"/> и реализует <see cref="ILogEntryRepository"/>.
    /// </summary>
    public class LogEntryRepository : DatabaseRepository<LogEntry>, ILogEntryRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="LogEntryRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        public LogEntryRepository(AppDbContext context, ILogger<LogEntryRepository> logger)
             : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<List<LogEntry>> GetByActionType(ActionType actionType, CancellationToken ct = default)
        {
            return await FindManyAsync(le => le.Action == actionType, ct);
        }

        /// <inheritdoc/>
        public async Task<List<LogEntry>> GetByDateRangeAsync(DateTime fromUtc, DateTime toUtc, CancellationToken ct = default)
        {
            return await FindManyAsync(le => le.ActionTime >= fromUtc && le.ActionTime <= toUtc, ct);
        }

        /// <inheritdoc/>
        public async Task<List<LogEntry>> GetBySessionAsync(int userSessionId, CancellationToken ct = default)
        {
            return await FindManyAsync(le => le.UserSessionId == userSessionId, ct);
        }
    }
}
