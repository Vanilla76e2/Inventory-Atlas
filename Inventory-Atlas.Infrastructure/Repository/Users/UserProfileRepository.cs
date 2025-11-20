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
        /// Инициализирует новый экземпляр репозитория профилей пользователей
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public UserProfileRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<UserProfileRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<UserProfile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserProfile>> GetActiveUsersAsync(CancellationToken ct = default)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<UserProfile>()
                .AsNoTracking()             
                .Where(u => u.IsActive)
                .ToListAsync(ct);
        }
    }
}