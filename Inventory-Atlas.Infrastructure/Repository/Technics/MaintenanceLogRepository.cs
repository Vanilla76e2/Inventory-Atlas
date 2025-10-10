using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с журналом технического обслуживания
    /// </summary>
    public class MaintenanceLogRepository : DatabaseRepository<MaintenanceLog>, IMaintenanceLogRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория журнала обслуживания
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public MaintenanceLogRepository(IDatabaseContextProvider contextProvider, ILogger<MaintenanceLogRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByDeviceIdAsync(int deviceId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<MaintenanceLog>()
                .Where(x => x.DeviceId == deviceId)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByEmployeeIdAsync(int employeeId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<MaintenanceLog>()
                .Where(x => x.PerformedBy == employeeId)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByDateRangeAsync(DateTime from, DateTime to)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<MaintenanceLog>()
                .Where(x => x.MaintenanceDate >= from && x.MaintenanceDate <= to)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByMaintenanceTypeAsync(MaintenanceType type)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<MaintenanceLog>()
                .Where(x => x.MaintenanceType == type)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync();
        }
    }
}