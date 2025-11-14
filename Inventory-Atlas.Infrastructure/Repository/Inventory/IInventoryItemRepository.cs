using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с элементами инвентаря.
    /// </summary>
    public interface IInventoryItemRepository : IDatabaseRepository<InventoryItem>
    {
        /// <summary>
        /// Выполняет поиск элементов инвентаря с возможностью фильтрации по нескольким параметрам.
        /// </summary>
        /// <param name="name">Название элемента (частичный поиск).</param>
        /// <param name="inventoryNumber">Инвентарный номер.</param>
        /// <param name="registryNumber">Регистрационный номер.</param>
        /// <param name="responsibleId">Идентификатор ответственного сотрудника.</param>
        /// <param name="status">Статус элемента инвентаря.</param>
        /// <param name="location">Местоположение элемента.</param>
        /// <returns>Список элементов инвентаря, соответствующих фильтрам.</returns>
        Task<IEnumerable<InventoryItem>> SearchAsync(
            string? name = null,
            string? inventoryNumber = null,
            string? registryNumber = null,
            int? responsibleId = null,
            InventoryStatus? status = null,
            string? location = null);
    }
}
