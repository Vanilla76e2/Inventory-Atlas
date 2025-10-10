using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с оборудованием
    /// </summary>
    public class EquipmentRepository : DatabaseRepository<Equipment>, IEquipmentRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория оборудования
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public EquipmentRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<EquipmentRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Equipment?> GetWithWorkplacesAndMaintenanceAsync(int equipmentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Equipment>()
                .Include(e => e.WorkplaceEquipments)
                .Include(e => e.MaintenanceLogs)
                .FirstOrDefaultAsync(e => e.Id == equipmentId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Equipment>> GetByWorkplaceIdAsync(int workplaceId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Equipment>()
                .Where(e => e.WorkplaceEquipments.Any(w => w.WorkplaceId == workplaceId))
                .ToListAsync();
        }
    }
}