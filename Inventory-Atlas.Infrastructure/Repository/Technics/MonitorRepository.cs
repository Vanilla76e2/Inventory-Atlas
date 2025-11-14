using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Entity = Inventory_Atlas.Infrastructure.Entities.Technics;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с мониторами
    /// </summary>
    public class MonitorRepository : DatabaseRepository<Entity.Monitor>, IMonitorRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория мониторов
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public MonitorRepository(IDatabaseContextProvider contextProvider, ILogger<MonitorRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Entity.Monitor>> GetByResolutionAsync(string resolution)
        {
            if (string.IsNullOrWhiteSpace(resolution) || !resolution.Contains("x"))
                return new List<Entity.Monitor>();

            var parts = resolution.Split('x');
            if (parts.Length != 2
                || !int.TryParse(parts[0], out var width)
                || !int.TryParse(parts[1], out var height))
                return new List<Entity.Monitor>();

            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<Entity.Monitor>()
                .Where(m => m.ResolutionWidth == width && m.ResolutionHeight == height)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Entity.Monitor>> GetByPanelTypeAsync(DisplayType panelType)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Entity.Monitor>()
                .Where(m => m.PanelType == panelType)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Entity.Monitor>> GetByRefreshRateRangeAsync(int min, int max)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Entity.Monitor>()
                .Where(m => m.RefreshRate >= min && m.RefreshRate <= max)
                .ToListAsync();
        }
    }
}