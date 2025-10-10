using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с избранными элементами пользователей
    /// </summary>
    public class FavouriteRepository : DatabaseRepository<Favourite>, IFavouriteRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория избранного
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public FavouriteRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<FavouriteRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Favourite>> GetByUserIdAsync(int userId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Favourite>()
                .Include(f => f.Item)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Favourite?> GetByUserAndItemAsync(int userId, int itemId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Favourite>()
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ItemId == itemId);
        }

        /// <inheritdoc/>
        public async Task<bool> IsFavouriteAsync(int userId, int itemId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Favourite>()
                .AnyAsync(f => f.UserId == userId && f.ItemId == itemId);
        }
    }
}