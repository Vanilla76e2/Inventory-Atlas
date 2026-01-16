using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с программным обеспечением
    /// </summary>
    public class SoftwareRepository : DatabaseRepository<Software>, ISoftwareRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория программного обеспечения.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public SoftwareRepository(AppDbContext context, ILogger<SoftwareRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Software>> GetByLicenceKeyAsync(string licenceKey, CancellationToken ct = default)
        {
            return await _context.Set<Software>()
                .Where(s => s.LicenceKey != null && s.LicenceKey == licenceKey)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Software>> GetByVendorAsync(string vendor, CancellationToken ct = default)
        {
            return await _context.Set<Software>()
                .Where(s => s.Vendor != null && s.Vendor == vendor)
                .ToListAsync(ct);
        }
    }
}