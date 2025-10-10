using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// Инициализирует новый экземпляр репозитория планшетов
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public TabletRepository(IDatabaseContextProvider contextProvider, ILogger<TabletRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tablet>> GetByOperatingSystemAsync(string operatingSystem)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Tablet>()
                .Where(t => t.OperatingSystem != null && t.OperatingSystem == operatingSystem)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Tablet>> GetByDiagonalAsync(float diagonal)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Tablet>()
                .Where(t => t.Diagonal.HasValue && t.Diagonal.Value == diagonal)
                .ToListAsync();
        }
    }
}