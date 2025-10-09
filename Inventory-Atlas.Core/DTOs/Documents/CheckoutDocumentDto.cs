using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    public class CheckoutDocumentDto : DocumentDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public List<CheckoutDocumentItemDto> Items { get; set; } = new();
    }

    public class CheckoutDocumentItemDto : BaseDto
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
    }
}
