using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с ИБП (источниками бесперебойного питания)
    /// </summary>
    public class UPSRepository : DatabaseRepository<UPS>, IUPSRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория ИБП.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public UPSRepository(AppDbContext context, ILogger<UPSRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UPS>> GetByCapacityAsync(int minWatts, int maxWatts, CancellationToken ct = default)
        {
            return await _context.Set<UPS>()
                .Where(u => u.CapacityWatts.HasValue && u.CapacityWatts.Value >= minWatts && u.CapacityWatts.Value <= maxWatts)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UPS>> GetByAutonomyAsync(int minMinutes, int maxMinutes, CancellationToken ct = default)
        {
            return await _context.Set<UPS>()
                .Where(u => u.Autonomy.HasValue && u.Autonomy.Value >= minMinutes && u.Autonomy.Value <= maxMinutes)
                .ToListAsync(ct);
        }
    }
}