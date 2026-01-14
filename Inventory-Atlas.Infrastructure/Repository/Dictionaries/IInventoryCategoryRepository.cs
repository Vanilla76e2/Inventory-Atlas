using Inventory_Atlas.Application.Entities.Services;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с категориями инвентаря
    /// </summary>
    public interface IInventoryCategoryRepository : IDatabaseRepository<InventoryCategory>
    {
        /// <summary>
        /// Получает категорию по названию
        /// </summary>
        /// <param name="name">Название категории</param>
        /// <returns>Категория инвентаря или null если не найдена</returns>
        Task<InventoryCategory?> GetByNameAsync(string name, CancellationToken ct = default);

        /// <summary>
        /// Получает категории с связанными элементами инвентаря
        /// </summary>
        /// <returns>Коллекция категорий с элементами инвентаря</returns>
        Task<IEnumerable<InventoryCategory>> GetWithItemsAsync(CancellationToken ct = default);
    }
}