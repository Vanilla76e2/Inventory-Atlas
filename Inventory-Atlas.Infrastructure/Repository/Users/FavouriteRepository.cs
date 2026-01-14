using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Users;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с избранными элементами пользователей
    /// </summary>
    public class FavouriteRepository : DatabaseRepository<Favourite>, IFavouriteRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория избранного.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public FavouriteRepository(AppDbContext context, ILogger<FavouriteRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Favourite>> GetByUserIdAsync(int userId, CancellationToken ct = default)
        {
            return await _context.Set<Favourite>()
                .Include(f => f.Item)
                .Where(f => f.UserId == userId)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<Favourite?> GetByUserAndItemAsync(int userId, int itemId, CancellationToken ct = default)
        {
            return await _context.Set<Favourite>()
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ItemId == itemId, ct);
        }

        /// <inheritdoc/>
        public async Task<bool> IsFavouriteAsync(int userId, int itemId, CancellationToken ct = default)
        {
            return await _context.Set<Favourite>()
                .AnyAsync(f => f.UserId == userId && f.ItemId == itemId, ct);
        }
    }
}