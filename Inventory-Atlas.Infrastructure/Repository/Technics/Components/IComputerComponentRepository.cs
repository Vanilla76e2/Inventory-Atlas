using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics.Components
{
    /// <summary>
    /// Репозиторий для работы с компонентами компьютеров
    /// </summary>
    /// <typeparam name="TComponent">Тип компонента компьютера</typeparam>
    public interface IComputerComponentRepository<TComponent> : IDatabaseRepository<TComponent>
        where TComponent : ComputerComponent
    {
        /// <summary>
        /// Получает компоненты по идентификатору компьютера
        /// </summary>
        /// <param name="computerId">Идентификатор компьютера</param>
        /// <returns>Коллекция компонентов компьютера</returns>
        Task<IEnumerable<TComponent>> GetByComputerIdAsync(int computerId);

        /// <summary>
        /// Получает компоненты по типу
        /// </summary>
        /// <param name="type">Тип компонента</param>
        /// <returns>Коллекция компонентов указанного типа</returns>
        Task<IEnumerable<TComponent>> GetByTypeAsync(ComponentType type);

        /// <summary>
        /// Находит компонент по серийному номеру
        /// </summary>
        /// <param name="serialNumber">Серийный номер</param>
        /// <returns>Компонент или null если не найден</returns>
        Task<TComponent?> GetBySerialNumberAsync(string serialNumber);
    }
}