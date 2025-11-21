using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Repository.Common;
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
        public MonitorRepository(AppDbContext context, ILogger<MonitorRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Entity.Monitor>> GetByResolutionAsync(string resolution, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(resolution) || !resolution.Contains("x"))
                return new List<Entity.Monitor>();

            var parts = resolution.Split('x');
            if (parts.Length != 2
                || !int.TryParse(parts[0], out var width)
                || !int.TryParse(parts[1], out var height))
                return new List<Entity.Monitor>();

            return await _context.Set<Entity.Monitor>()
                .Where(m => m.ResolutionWidth == width && m.ResolutionHeight == height)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Entity.Monitor>> GetByPanelTypeAsync(DisplayType panelType, CancellationToken ct = default)
        {
            return await _context.Set<Entity.Monitor>()
                .Where(m => m.PanelType == panelType)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Entity.Monitor>> GetByRefreshRateRangeAsync(int min, int max, CancellationToken ct = default)
        {
            return await _context.Set<Entity.Monitor>()
                .Where(m => m.RefreshRate >= min && m.RefreshRate <= max)
                .ToListAsync(ct);
        }
    }
}