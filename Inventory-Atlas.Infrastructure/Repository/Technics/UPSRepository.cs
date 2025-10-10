using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с ИБП (источниками бесперебойного питания)
    /// </summary>
    public class UPSRepository : DatabaseRepository<UPS>, IUPSRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория ИБП
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public UPSRepository(IDatabaseContextProvider contextProvider, ILogger<UPSRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UPS>> GetByCapacityAsync(int minWatts, int maxWatts)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<UPS>()
                .Where(u => u.CapacityWatts.HasValue && u.CapacityWatts.Value >= minWatts && u.CapacityWatts.Value <= maxWatts)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UPS>> GetByAutonomyAsync(int minMinutes, int maxMinutes)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<UPS>()
                .Where(u => u.Autonomy.HasValue && u.Autonomy.Value >= minMinutes && u.Autonomy.Value <= maxMinutes)
                .ToListAsync();
        }
    }
}