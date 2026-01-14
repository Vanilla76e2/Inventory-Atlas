using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Inventory;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с фотографиями элементов инвентаря.
    /// </summary>
    public class InventoryPhotoRepository : DatabaseRepository<InventoryPhoto>, IInventoryPhotoRepository
    {
        /// <summary>
        /// Создаёт новый экземпляр репозитория фотографий элементов инвентаря.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер репозитория.</param>
        public InventoryPhotoRepository( AppDbContext context, ILogger<InventoryPhotoRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryPhoto>> GetByInventoryItemIdAsync(int inventoryItemId, CancellationToken ct = default)
        {
            return await _context.Set<InventoryPhoto>()
                .Where(p => p.InventoryItemId == inventoryItemId)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<InventoryPhoto?> GetPrimaryPhotoAsync(int inventoryItemId, CancellationToken ct = default)
        {
            return await _context.Set<InventoryPhoto>()
                .FirstOrDefaultAsync(p => p.InventoryItemId == inventoryItemId && p.IsPrimary, ct);
        }
    }
}
