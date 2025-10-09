using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    public class WorkplaceDto : AuditableDto
    {
        public string Name { get; set; } = null!;
        public string? Comment { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public List<WorkplaceEquipmentDto>? Equipments { get; set; }
    }

    public class WorkplaceEquipmentDto : BaseDto
    {
        public int WorkplaceId { get; set; }
        public int EquipmentId { get; set; }

        public WorkplaceDto? Workplace { get; set; }
        public EquipmentDto? Equipment { get; set; }
    }
}
