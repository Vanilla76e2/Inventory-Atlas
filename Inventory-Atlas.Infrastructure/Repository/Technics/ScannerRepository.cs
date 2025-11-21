using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы со сканерами
    /// </summary>
    public class ScannerRepository : DatabaseRepository<Scanner>, IScannerRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория сканеров.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public ScannerRepository(AppDbContext context, ILogger<ScannerRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Scanner>> GetByIpAddressAsync(string ipAddress, CancellationToken ct = default)
        {
            return await _context.Set<Scanner>()
                .Where(s => s.IpAddress != null && s.IpAddress.ToString() == ipAddress)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Scanner>> GetByColorScanningAsync(bool isColor, CancellationToken ct = default)
        {
            return await _context.Set<Scanner>()
                .Where(s => s.Color == isColor)
                .ToListAsync(ct);
        }
    }
}