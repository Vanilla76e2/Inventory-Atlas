using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    public class WorkplaceEquipmentRepository : DatabaseRepository<WorkplaceEquipmentRepository>, IWorkplaceEquipmentRepository
    {
        public WorkplaceEquipmentRepository(IDatabaseContextProvider contextProvider, ILogger<WorkplaceEquipmentRepository> logger)
             : base(contextProvider, logger)
        {
        }
    }
}
