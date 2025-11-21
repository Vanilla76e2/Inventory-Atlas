using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
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
        /// Инициализирует новый экземпляр репозитория журнала обслуживания.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public MaintenanceLogRepository(AppDbContext context, ILogger<MaintenanceLogRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByDeviceIdAsync(int deviceId, CancellationToken ct = default)
        {
            return await _context.Set<MaintenanceLog>()
                .Where(x => x.DeviceId == deviceId)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByEmployeeIdAsync(int employeeId, CancellationToken ct = default)
        {
            return await _context.Set<MaintenanceLog>()
                .Where(x => x.PerformedBy == employeeId)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
        {
            return await _context.Set<MaintenanceLog>()
                .Where(x => x.MaintenanceDate >= from && x.MaintenanceDate <= to)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaintenanceLog>> GetByMaintenanceTypeAsync(MaintenanceType type, CancellationToken ct = default)
        {
            return await _context.Set<MaintenanceLog>()
                .Where(x => x.MaintenanceType == type)
                .Include(x => x.Device)
                .Include(x => x.Employee)
                .ToListAsync(ct);
        }
    }
}