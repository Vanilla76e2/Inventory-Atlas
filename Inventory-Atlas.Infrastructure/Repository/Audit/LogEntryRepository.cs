using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        public LogEntryRepository(IDatabaseContextProvider contextProvider, ILogger<LogEntryRepository> logger)
             : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LogEntry>> GetByActionType(ActionType actionType)
        {
            return await FindManyAsync(le => le.Action == actionType);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LogEntry>> GetByDateRangeAsync(DateTime fromUtc, DateTime toUtc)
        {
            return await FindManyAsync(le => le.ActionTime >= fromUtc && le.ActionTime <= toUtc);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LogEntry>> GetBySessionAsync(Guid userSessionId)
        {
            return await FindManyAsync(le => le.UserSessionId == userSessionId);
        }
    }
}
