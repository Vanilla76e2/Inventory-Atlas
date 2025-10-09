using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Employees;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class MaintenanceLogDto : BaseDto
    {
        public int DeviceId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public Core.Enums.MaintenanceType MaintenanceType { get; set; }
        public int PerformedBy { get; set; }
        public string? Comment { get; set; }

        // Опциональные вложенные объекты
        public EquipmentDto? Device { get; set; }
        public EmployeeDto? Employee { get; set; }
    }
}
