using Inventory_Atlas.Application.Entities.Audit;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Audit
{
    /// <summary>
    /// Репозиторий для работы с сессиями пользователей.
    /// <para/>
    /// Тип: <see cref="IUserSessionRepository"/>
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{T}"/> для базовых операций CRUD.
    /// </summary>
    public interface IUserSessionRepository : IDatabaseRepository<UserSession>
    {
        Task<UserSession?> GetSessionByToken(string token, CancellationToken ct = default);

        /// <summary>
        /// Получить активную сессию пользователя по имени пользователя.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="UserSession"/>
        /// <para/>
        /// Может быть <c>null</c>, если активная сессия отсутствует.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        Task<List<UserSession>> GetActiveSessionsByUsernameAsync(string username, CancellationToken ct = default);

        /// <summary>
        /// Получить все сессии пользователя по имени пользователя.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="IEnumerable{UserSession}"/>
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        Task<List<UserSession>> GetSessionsByUsernameAsync(string username, CancellationToken ct = default);

        /// <summary>
        /// Получить все сессии пользователей в указанном диапазоне дат.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="IEnumerable{UserSession}"/>
        /// </summary>
        /// <param name="fromUtc">Начальная дата диапазона (UTC).</param>
        /// <param name="toUtc">Конечная дата диапазона (UTC).</param>
        Task<IEnumerable<UserSession>> GetSessionsInRangeAsync(DateTime fromUtc, DateTime toUtc, CancellationToken ct = default);

        Task<UserSession?> GetActiveSessionByTokenAsync(string token, CancellationToken ct = default);
    }
}
