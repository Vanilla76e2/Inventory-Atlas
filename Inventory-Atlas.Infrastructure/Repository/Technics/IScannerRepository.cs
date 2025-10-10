using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы со сканерами
    /// </summary>
    public interface IScannerRepository : IDatabaseRepository<Scanner>
    {
        /// <summary>
        /// Получает сканеры по IP-адресу
        /// </summary>
        /// <param name="ipAddress">IP-адрес для поиска</param>
        /// <returns>Коллекция сканеров с указанным IP-адресом</returns>
        Task<IEnumerable<Scanner>> GetByIpAddressAsync(string ipAddress);

        /// <summary>
        /// Получает сканеры по типу сканирования
        /// </summary>
        /// <param name="isColor">Признак цветного сканирования (true - цветные, false - черно-белые)</param>
        /// <returns>Коллекция сканеров с указанным типом сканирования</returns>
        Task<IEnumerable<Scanner>> GetByColorScanningAsync(bool isColor);
    }
}