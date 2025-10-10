using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с общими позициями инвентаря.
    /// </summary>
    public interface IGenericInventoryItemRepository : IDatabaseRepository<GenericInventoryItem>
    {
        /// <summary>
        /// Получает все позиции инвентаря, относящиеся к указанной категории.
        /// </summary>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <returns>Список элементов инвентаря, принадлежащих категории.</returns>
        Task<IEnumerable<GenericInventoryItem>> GetByCategoryIdAsync(int categoryId);

        /// <summary>
        /// Выполняет поиск элементов инвентаря с возможностью фильтрации по имени, категории и JSON-свойствам.
        /// </summary>
        /// <param name="name">Имя элемента (частичный поиск).</param>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <param name="jsonPropertyKey">Ключ свойства в JSON.</param>
        /// <param name="jsonPropertyValue">Значение свойства в JSON.</param>
        /// <returns>Список элементов инвентаря, соответствующих фильтрам.</returns>
        Task<IEnumerable<GenericInventoryItem>> SearchAsync(
            string? name = null,
            int? categoryId = null,
            string? jsonPropertyKey = null,
            string? jsonPropertyValue = null);
    }
}
