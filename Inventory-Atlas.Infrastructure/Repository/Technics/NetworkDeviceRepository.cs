using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с сетевыми устройствами
    /// </summary>
    public class NetworkDeviceRepository : DatabaseRepository<NetworkDevice>, INetworkDeviceRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория сетевых устройств
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public NetworkDeviceRepository(IDatabaseContextProvider contextProvider, ILogger<NetworkDeviceRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NetworkDevice>> GetByIpAddressAsync(IPAddress ipAddress)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<NetworkDevice>()
                .Where(d => d.IpAddress != null && d.IpAddress.Equals(ipAddress))
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NetworkDevice>> GetByVendorAsync(string vendor)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<NetworkDevice>()
                .Where(d => d.Vendor != null && d.Vendor.ToLower() == vendor.ToLower())
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NetworkDevice>> GetWithWifiAsync(bool hasWifi = true)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<NetworkDevice>()
                .Where(d => d.HasWifi == hasWifi)
                .ToListAsync();
        }
    }
}