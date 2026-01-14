using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Services;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с категориями инвентаря
    /// </summary>
    public class InventoryCategoryRepository : DatabaseRepository<InventoryCategory>, IInventoryCategoryRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория категорий инвентаря.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public InventoryCategoryRepository(
            AppDbContext context,
            ILogger<InventoryCategoryRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<InventoryCategory?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return await _context.Set<InventoryCategory>()
                .FirstOrDefaultAsync(c => c.Name == name, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryCategory>> GetWithItemsAsync(CancellationToken ct = default)
        {
            return await _context.Set<InventoryCategory>()
                .Include(c => c.CustomFields)
                .ToListAsync(ct);
        }
    }
}