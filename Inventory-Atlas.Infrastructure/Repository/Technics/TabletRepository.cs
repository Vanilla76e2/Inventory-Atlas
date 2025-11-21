using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с планшетами
    /// </summary>
    public class TabletRepository : DatabaseRepository<Tablet>, ITabletRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория планшетов.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public TabletRepository(AppDbContext context, ILogger<TabletRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tablet>> GetByOperatingSystemAsync(string operatingSystem, CancellationToken ct = default)
        {
            return await _context.Set<Tablet>()
                .Where(t => t.OperatingSystem != null && t.OperatingSystem == operatingSystem)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tablet>> GetByDiagonalAsync(float diagonal, CancellationToken ct = default)
        {
            return await _context.Set<Tablet>()
                .Where(t => t.Diagonal.HasValue && t.Diagonal.Value == diagonal)
                .ToListAsync(ct);
        }
    }
}