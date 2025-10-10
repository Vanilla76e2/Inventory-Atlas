using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с общими элементами инвентаря.
    /// </summary>
    public class GenericInventoryRepository : DatabaseRepository<GenericInventoryItem>, IGenericInventoryItemRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="GenericInventoryRepository"/>.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public GenericInventoryRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<GenericInventoryRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GenericInventoryItem>> GetByCategoryIdAsync(int categoryId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<GenericInventoryItem>()
                .Where(i => i.CategoryId == categoryId)
                .Include(i => i.Category)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GenericInventoryItem>> SearchAsync(
            string? name = null,
            int? categoryId = null,
            string? jsonPropertyKey = null,
            string? jsonPropertyValue = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<GenericInventoryItem>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(i => EF.Functions.ILike(i.Name, $"%{name}%"));

            if (categoryId.HasValue)
                query = query.Where(i => i.CategoryId == categoryId);

            // Поиск по JSON-свойству (PostgreSQL jsonb)
            if (!string.IsNullOrWhiteSpace(jsonPropertyKey) && !string.IsNullOrWhiteSpace(jsonPropertyValue))
            {
                query = query.Where(i => EF.Functions.JsonContains(i.Properties, $"{{\"{jsonPropertyKey}\":\"{jsonPropertyValue}\"}}"));
            }

            return await query.Include(i => i.Category).ToListAsync();
        }
    }
}
