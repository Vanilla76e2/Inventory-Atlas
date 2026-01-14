using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;
using System.Net;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с сетевыми устройствами
    /// </summary>
    public interface INetworkDeviceRepository : IDatabaseRepository<NetworkDevice>
    {
        /// <summary>
        /// Получает сетевые устройства по IpAddress-адресу
        /// </summary>
        /// <param name="ipAddress">IpAddress-адрес для поиска</param>
        /// <returns>Коллекция сетевых устройств с указанным IpAddress-адресом</returns>
        Task<IEnumerable<NetworkDevice>> GetByIpAddressAsync(IPAddress ipAddress, CancellationToken ct = default);

        /// <summary>
        /// Получает сетевые устройства по производителю
        /// </summary>
        /// <param name="vendor">Производитель устройства</param>
        /// <returns>Коллекция сетевых устройств указанного производителя</returns>
        Task<IEnumerable<NetworkDevice>> GetByVendorAsync(string vendor, CancellationToken ct = default);

        /// <summary>
        /// Получает сетевые устройства с поддержкой Wi-Fi
        /// </summary>
        /// <param name="hasWifi">Признак наличия Wi-Fi (true - с Wi-Fi, false - без Wi-Fi)</param>
        /// <returns>Коллекция сетевых устройств с указанной поддержкой Wi-Fi</returns>
        Task<IEnumerable<NetworkDevice>> GetWithWifiAsync(bool hasWifi = true, CancellationToken ct = default);
    }
}