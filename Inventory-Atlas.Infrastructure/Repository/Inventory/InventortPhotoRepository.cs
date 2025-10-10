using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с фотографиями элементов инвентаря.
    /// </summary>
    public class InventoryPhotoRepository : DatabaseRepository<InventoryPhoto>, IInventoryPhotoRepository
    {
        /// <summary>
        /// Создаёт новый экземпляр репозитория фотографий элементов инвентаря.
        /// </summary>
        /// <param name="contextProvider">Провайдер DbContext.</param>
        /// <param name="logger">Логгер репозитория.</param>
        public InventoryPhotoRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<InventoryPhotoRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryPhoto>> GetByInventoryItemIdAsync(int inventoryItemId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<InventoryPhoto>()
                .Where(p => p.InventoryItemId == inventoryItemId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<InventoryPhoto?> GetPrimaryPhotoAsync(int inventoryItemId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<InventoryPhoto>()
                .FirstOrDefaultAsync(p => p.InventoryItemId == inventoryItemId && p.IsPrimary);
        }
    }
}
