using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с компьютерами
    /// </summary>
    public interface IComputerRepository : IDatabaseRepository<Computer>
    {
        /// <summary>
        /// Получает компьютер с его компонентами и оборудованием рабочих мест
        /// </summary>
        /// <param name="computerId">Идентификатор компьютера</param>
        /// <returns>Компьютер с связанными данными или null если не найден</returns>
        Task<Computer?> GetWithComponentsAsync(int computerId, CancellationToken ct = default);

        /// <summary>
        /// Получает все серверы в системе
        /// </summary>
        /// <returns>Коллекция серверов</returns>
        Task<IEnumerable<Computer>> GetServersAsync(CancellationToken ct = default);

        /// <summary>
        /// Получает компьютеры по IpAddress-адресу
        /// </summary>
        /// <param name="ipAddress">IpAddress-адрес для поиска</param>
        /// <returns>Коллекция компьютеров с указанным IpAddress-адресом</returns>
        Task<IEnumerable<Computer>> GetByIpAsync(System.Net.IPAddress ipAddress, CancellationToken ct = default);

        /// <summary>
        /// Получает компьютер, которому принадлежит компонент с указанным идентификатором
        /// </summary>
        /// <param name="componentId">Идентификатор компонента</param>
        /// <returns>Компьютер с компонентами или null если не найден</returns>
        Task<Computer?> GetByComponentIdAsync(int componentId, CancellationToken ct = default);

        /// <summary>
        /// Получает компьютер, которому принадлежит компонент указанного типа и идентификатора
        /// </summary>
        /// <param name="componentId">Идентификатор компонента</param>
        /// <param name="type">Тип компонента</param>
        /// <returns>Компьютер с компонентами или null если не найден</returns>
        Task<Computer?> GetByComponentAsync(int componentId, ComponentType type, CancellationToken ct = default);
    }
}