using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с мебелью.
    /// </summary>
    public interface IFurnitureRepository : IDatabaseRepository<Furniture>
    {
        /// <summary>
        /// Выполняет поиск мебели с возможностью фильтрации по типу, ориентации, весу и размеру.
        /// </summary>
        /// <param name="typeId">Идентификатор типа мебели.</param>
        /// <param name="orientation">Ориентация мебели.</param>
        /// <param name="minWeight">Минимальный вес.</param>
        /// <param name="maxWeight">Максимальный вес.</param>
        /// <param name="dimensionsContains">Подстрока, которая должна присутствовать в описании размеров.</param>
        /// <returns>Список элементов мебели, соответствующих фильтрам.</returns>
        Task<IEnumerable<Furniture>> SearchAsync(
            int? typeId = null,
            FurnitureOrientation? orientation = null,
            double? minWeight = null,
            double? maxWeight = null,
            string? dimensionsContains = null);
    }

    /// <summary>
    /// Репозиторий для работы с назначениями материалов мебели.
    /// </summary>
    public interface IFurnitureMaterialAssignmentRepository : IDatabaseRepository<FurnitureMaterialAssignment>
    {
        /// <summary>
        /// Получает назначения материалов для указанной мебели.
        /// </summary>
        /// <param name="furnitureId">Идентификатор мебели.</param>
        /// <returns>Список назначений материалов.</returns>
        Task<IEnumerable<FurnitureMaterialAssignment>> GetByFurnitureIdAsync(int furnitureId);

        /// <summary>
        /// Получает назначения мебели, в которых используется указанный материал.
        /// </summary>
        /// <param name="materialId">Идентификатор материала.</param>
        /// <returns>Список назначений мебели с данным материалом.</returns>
        Task<IEnumerable<FurnitureMaterialAssignment>> GetByMaterialIdAsync(int materialId);
    }
}
