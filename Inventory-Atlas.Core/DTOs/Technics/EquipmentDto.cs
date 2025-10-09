using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Core.DTOs.Inventory;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class EquipmentDto : InventoryItemDto
    {
        public List<WorkplaceEquipmentDto> WorkplaceEquipments { get; set; } = new();
        public List<MaintenanceLogDto> MaintenanceLogs { get; set; } = new();
    }
}
