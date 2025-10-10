using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с типами мебели.
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{FurnitureType}"/>.
    /// </summary>
    public interface IFurnitureTypeRepository : IDatabaseRepository<FurnitureType>
    {
        /// <summary>
        /// Выполняет поиск типов мебели по имени.
        /// </summary>
        /// <param name="name">Название типа мебели (опционально, поиск по подстроке, нечувствительно к регистру).</param>
        /// <returns>Список объектов <see cref="FurnitureType"/>, удовлетворяющих фильтру.</returns>
        Task<IEnumerable<FurnitureType>> SearchAsync(string? name = null);
    }
}
