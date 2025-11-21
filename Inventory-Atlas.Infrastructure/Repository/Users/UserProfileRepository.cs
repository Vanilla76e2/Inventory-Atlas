using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с профилями пользователей
    /// </summary>
    public class UserProfileRepository : DatabaseRepository<UserProfile>, IUserProfileRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория профилей пользователей.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public UserProfileRepository(AppDbContext context, ILogger<UserProfileRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            return await _context.Set<UserProfile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username, ct);
        }

        /// <inheritdoc/>
        public async Task<List<UserProfile>> GetActiveUsersAsync(CancellationToken ct = default)
        {
            return await _context.Set<UserProfile>()
                .AsNoTracking()             
                .Where(u => u.IsActive)
                .ToListAsync(ct);
        }
    }
}