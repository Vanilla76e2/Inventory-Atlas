using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Audit
{
    /// <summary>
    /// Репозиторий для работы с записями лога действий пользователя.
    /// <para/>
    /// Тип: <see cref="ILogEntryRepository"/>
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{T}"/> для базовых операций CRUD.
    /// </summary>
    public interface ILogEntryRepository : IDatabaseRepository<LogEntry>
    {
        /// <summary>
        /// Получить все записи лога, связанные с конкретной сессией пользователя.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="IEnumerable{LogEntry}"/>
        /// </summary>
        /// <param name="userSessionId">Идентификатор сессии пользователя.</param>
        Task<IEnumerable<LogEntry>> GetBySessionAsync(Guid userSessionId);

        /// <summary>
        /// Получить все записи лога по типу действия.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="IEnumerable{LogEntry}"/>
        /// </summary>
        /// <param name="actionType">Тип действия из <see cref="ActionType"/>.</param>
        Task<IEnumerable<LogEntry>> GetByActionType(ActionType actionType);

        /// <summary>
        /// Получить все записи лога за указанный диапазон дат.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="IEnumerable{LogEntry}"/>
        /// </summary>
        /// <param name="fromUtc">Начальная дата диапазона (UTC).</param>
        /// <param name="toUtc">Конечная дата диапазона (UTC).</param>
        Task<IEnumerable<LogEntry>> GetByDateRangeAsync(DateTime fromUtc, DateTime toUtc);
    }
}
