using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
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
        /// Инициализирует новый экземпляр репозитория ролей.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public RoleRepository(AppDbContext context, ILogger<RoleRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Role?> GetByNameAsync(string roleName, CancellationToken ct = default)
        {
            return await _context.Set<Role>()
                .FirstOrDefaultAsync(r => r.Name == roleName);
        }

        /// <inheritdoc/>
        public async Task<List<Role>> GetSystemRolesAsync(CancellationToken ct = default)
        {
            return await _context.Set<Role>()
                .Where(r => r.IsSystem)
                .ToListAsync(ct);
        }
    }
}