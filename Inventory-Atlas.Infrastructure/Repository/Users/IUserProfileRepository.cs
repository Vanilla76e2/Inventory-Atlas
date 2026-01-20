using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с профилями пользователей
    /// </summary>
    public interface IUserProfileRepository : IDatabaseRepository<UserProfile>
    {
        /// <summary>
        /// Получает профиль пользователя по имени пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <returns>Профиль пользователя или null если не найден</returns>
        Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default);

        /// <summary>
        /// Получает активных пользователей
        /// </summary>
        /// <returns>Коллекция активных пользователей</returns>
        Task<List<UserProfile>> GetActiveUsersAsync(CancellationToken ct = default);

        /// <summary>
        /// Получает профиль пользователя вместе с ролью по имени пользователя.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="ct">Токен отмены.</param>
        Task<UserProfile?> GetWithRoleByUsername(string username, CancellationToken ct = default);

        /// <summary>
        /// Получает всех пользователей вместе с их ролями.
        /// </summary>
        /// <param name="ct">Токен отмены.</param>
        Task<List<UserProfile>> GetAllWithRolesAsync(CancellationToken ct = default);
    }
}