using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    public class WorkplaceEquipmentRepository : DatabaseRepository<WorkplaceEquipmentRepository>, IWorkplaceEquipmentRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="WorkplaceEquipmentRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public WorkplaceEquipmentRepository(AppDbContext context, ILogger<WorkplaceEquipmentRepository> logger)
             : base(context, logger)
        {
        }
    }
}
