using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с фотографиями элементов инвентаря.
    /// </summary>
    public interface IInventoryPhotoRepository : IDatabaseRepository<InventoryPhoto>
    {
        /// <summary>
        /// Получает все фотографии, связанные с указанным элементом инвентаря.
        /// </summary>
        /// <param name="inventoryItemId">Идентификатор элемента инвентаря.</param>
        /// <returns>Список фотографий, связанных с элементом.</returns>
        Task<IEnumerable<InventoryPhoto>> GetByInventoryItemIdAsync(int inventoryItemId);

        /// <summary>
        /// Получает основную (главную) фотографию элемента инвентаря.
        /// </summary>
        /// <param name="inventoryItemId">Идентификатор элемента инвентаря.</param>
        /// <returns>Главная фотография элемента инвентаря или <c>null</c>, если фотографий нет.</returns>
        Task<InventoryPhoto?> GetPrimaryPhotoAsync(int inventoryItemId);
    }
}
