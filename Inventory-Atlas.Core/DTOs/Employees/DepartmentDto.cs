using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    public class DepartmentDto : AuditableDto
    {
        public string Name { get; set; } = null!;
        public string? Comment { get; set; }
        public List<EmployeeSummaryDto>? Employees { get; set; } // Опционально для UI
    }
}
