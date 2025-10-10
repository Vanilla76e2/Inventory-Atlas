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
        /// Получает ноутбук по IP-адресу
        /// </summary>
        /// <param name="ipAddress">IP-адрес для поиска</param>
        /// <returns>Ноутбук с указанным IP-адресом или null если не найден</returns>
        Task<Laptop?> GetByIpAddressAsync(string ipAddress);

        /// <summary>
        /// Получает ноутбуки по процессору
        /// </summary>
        /// <param name="processor">Модель процессора для поиска</param>
        /// <returns>Коллекция ноутбуков с указанным процессором</returns>
        Task<IEnumerable<Laptop>> GetByProcessorAsync(string processor);

        /// <summary>
        /// Получает ноутбуки по объему оперативной памяти
        /// </summary>
        /// <param name="ram">Объем оперативной памяти в ГБ</param>
        /// <returns>Коллекция ноутбуков с указанным объемом RAM</returns>
        Task<IEnumerable<Laptop>> GetByRAMAsync(int ram);
    }
}