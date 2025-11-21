using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
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
        public NetworkDeviceRepository(AppDbContext context, ILogger<NetworkDeviceRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NetworkDevice>> GetByIpAddressAsync(IPAddress ipAddress, CancellationToken ct = default)
        {
            return await _context.Set<NetworkDevice>()
                .Where(d => d.IpAddress != null && d.IpAddress.Equals(ipAddress))
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NetworkDevice>> GetByVendorAsync(string vendor, CancellationToken ct = default)
        {
            return await _context.Set<NetworkDevice>()
                .Where(d => d.Vendor != null && d.Vendor.ToLower() == vendor.ToLower())
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<NetworkDevice>> GetWithWifiAsync(bool hasWifi = true, CancellationToken ct = default)
        {
            return await _context.Set<NetworkDevice>()
                .Where(d => d.HasWifi == hasWifi)
                .ToListAsync(ct);
        }
    }
}