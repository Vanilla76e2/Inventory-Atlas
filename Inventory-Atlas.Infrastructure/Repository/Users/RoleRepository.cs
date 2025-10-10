using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с ролями пользователей
    /// </summary>
    public class RoleRepository : DatabaseRepository<Role>, IRoleRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория ролей
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public RoleRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<RoleRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Role?> GetByNameAsync(string roleName)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Role>()
                .FirstOrDefaultAsync(r => r.Name == roleName);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Role>> GetSystemRolesAsync()
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Role>()
                .Where(r => r.IsSystem)
                .ToListAsync();
        }
    }
}