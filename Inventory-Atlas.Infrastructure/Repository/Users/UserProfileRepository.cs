using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        public async Task<UserProfile?> GetByUsernameAsync(string username)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<UserProfile>()
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserProfile>> GetActiveUsersAsync()
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<UserProfile>()
                .Where(u => u.IsActive)
                .ToListAsync();
        }
    }
}