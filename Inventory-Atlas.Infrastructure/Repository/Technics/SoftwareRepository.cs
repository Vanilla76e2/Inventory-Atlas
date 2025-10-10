using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// Инициализирует новый экземпляр репозитория программного обеспечения
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public SoftwareRepository(IDatabaseContextProvider contextProvider, ILogger<SoftwareRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Software>> GetByLicenceKeyAsync(string licenceKey)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Software>()
                .Where(s => s.LicenceKey != null && s.LicenceKey == licenceKey)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Software>> GetByVendorAsync(string vendor)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Software>()
                .Where(s => s.Vendor != null && s.Vendor == vendor)
                .ToListAsync();
        }
    }
}