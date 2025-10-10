using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с материалами мебели.
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{FurnitureMaterial}"/>.
    /// </summary>
    public interface IFurnitureMaterialRepository : IDatabaseRepository<FurnitureMaterial>
    {
        /// <summary>
        /// Выполняет поиск материалов мебели по имени.
        /// </summary>
        /// <param name="name">Название материала (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <returns>Список объектов <see cref="FurnitureMaterial"/>, удовлетворяющих фильтру.</returns>
        Task<IEnumerable<FurnitureMaterial>> SearchAsync(string? name = null);
    }
}
