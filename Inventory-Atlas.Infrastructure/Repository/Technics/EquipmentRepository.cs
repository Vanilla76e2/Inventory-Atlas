using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с оборудованием
    /// </summary>
    public class EquipmentRepository : DatabaseRepository<Equipment>, IEquipmentRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория оборудования.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public EquipmentRepository(AppDbContext context, ILogger<EquipmentRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Equipment?> GetWithWorkplacesAndMaintenanceAsync(int equipmentId, CancellationToken ct = default)
        {
            return await _context.Set<Equipment>()
                .Include(e => e.WorkplaceEquipments)
                .Include(e => e.MaintenanceLogs)
                .FirstOrDefaultAsync(e => e.Id == equipmentId, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Equipment>> GetByWorkplaceIdAsync(int workplaceId, CancellationToken ct = default)
        {
            return await _context.Set<Equipment>()
                .Where(e => e.WorkplaceEquipments.Any(w => w.WorkplaceId == workplaceId))
                .ToListAsync(ct);
        }
    }
}