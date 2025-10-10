using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с категориями инвентаря
    /// </summary>
    public class InventoryCategoryRepository : DatabaseRepository<InventoryCategory>, IInventoryCategoryRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория категорий инвентаря
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public InventoryCategoryRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<InventoryCategoryRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<InventoryCategory?> GetByNameAsync(string name)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<InventoryCategory>()
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryCategory>> GetWithItemsAsync()
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<InventoryCategory>()
                .Include(c => c.Items)
                .ToListAsync();
        }
    }
}