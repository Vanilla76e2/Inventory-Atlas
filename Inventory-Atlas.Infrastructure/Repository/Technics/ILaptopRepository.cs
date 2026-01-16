using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с ноутбуками
    /// </summary>
    public interface ILaptopRepository : IDatabaseRepository<Laptop>
    {
        /// <summary>
        /// Получает ноутбук по IpAddress-адресу
        /// </summary>
        /// <param name="ipAddress">IpAddress-адрес для поиска</param>
        /// <returns>Ноутбук с указанным IpAddress-адресом или null если не найден</returns>
        Task<Laptop?> GetByIpAddressAsync(string ipAddress, CancellationToken ct = default);

        /// <summary>
        /// Получает ноутбуки по процессору
        /// </summary>
        /// <param name="processor">Модель процессора для поиска</param>
        /// <returns>Коллекция ноутбуков с указанным процессором</returns>
        Task<IEnumerable<Laptop>> GetByProcessorAsync(string processor, CancellationToken ct = default);

        /// <summary>
        /// Получает ноутбуки по объему оперативной памяти
        /// </summary>
        /// <param name="ram">Объем оперативной памяти в ГБ</param>
        /// <returns>Коллекция ноутбуков с указанным объемом RAM</returns>
        Task<IEnumerable<Laptop>> GetByRAMAsync(int ram, CancellationToken ct = default);
    }
}