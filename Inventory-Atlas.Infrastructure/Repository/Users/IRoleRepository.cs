using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с ролями пользователей
    /// </summary>
    public interface IRoleRepository : IDatabaseRepository<Role>
    {
        /// <summary>
        /// Получает роль по названию
        /// </summary>
        /// <param name="roleName">Название роли</param>
        /// <returns>Роль с указанным названием или null если не найдена</returns>
        Task<Role?> GetByNameAsync(string roleName, CancellationToken ct = default);

        /// <summary>
        /// Получает системные роли
        /// </summary>
        /// <returns>Коллекция системных ролей</returns>
        Task<List<Role>> GetSystemRolesAsync(CancellationToken ct = default);
    }
}