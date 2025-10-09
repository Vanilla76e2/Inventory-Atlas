using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    public class ReturnDocumentDto : DocumentDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public List<ReturnDocumentItemDto> Items { get; set; } = new();
    }

    public class ReturnDocumentItemDto : BaseDto
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
    }
}
