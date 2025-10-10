using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// Инициализирует новый экземпляр репозитория сканеров
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public ScannerRepository(IDatabaseContextProvider contextProvider, ILogger<ScannerRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Scanner>> GetByIpAddressAsync(string ipAddress)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Scanner>()
                .Where(s => s.IpAddress != null && s.IpAddress.ToString() == ipAddress)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Scanner>> GetByColorScanningAsync(bool isColor)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Scanner>()
                .Where(s => s.Color == isColor)
                .ToListAsync();
        }
    }
}