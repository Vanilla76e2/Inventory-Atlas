using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    public class MateriallyResponsibleDto : BaseDto
    {
        public int EmployeeId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? Comment { get; set; }
        public List<InventoryItemDto>? Items { get; set; }
    }
}
