using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы со сканерами
    /// </summary>
    public interface IScannerRepository : IDatabaseRepository<Scanner>
    {
        /// <summary>
        /// Получает сканеры по IpAddress-адресу
        /// </summary>
        /// <param name="ipAddress">IpAddress-адрес для поиска</param>
        /// <returns>Коллекция сканеров с указанным IpAddress-адресом</returns>
        Task<IEnumerable<Scanner>> GetByIpAddressAsync(string ipAddress, CancellationToken ct = default);

        /// <summary>
        /// Получает сканеры по типу сканирования
        /// </summary>
        /// <param name="isColor">Признак цветного сканирования (true - цветные, false - черно-белые)</param>
        /// <returns>Коллекция сканеров с указанным типом сканирования</returns>
        Task<IEnumerable<Scanner>> GetByColorScanningAsync(bool isColor, CancellationToken ct = default);
    }
}