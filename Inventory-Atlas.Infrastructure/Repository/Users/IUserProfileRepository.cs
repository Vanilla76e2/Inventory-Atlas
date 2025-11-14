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
        Task<UserProfile?> GetByUsernameAsync(string username);

        /// <summary>
        /// Получает активных пользователей
        /// </summary>
        /// <returns>Коллекция активных пользователей</returns>
        Task<IEnumerable<UserProfile>> GetActiveUsersAsync();
    }
}