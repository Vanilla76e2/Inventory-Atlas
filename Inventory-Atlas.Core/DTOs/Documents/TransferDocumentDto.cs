using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    public class TransferDocumentDto : DocumentDto
    {
        public int FromEmployeeId { get; set; }
        public string FromEmployeeName { get; set; } = null!;
        public int ToEmployeeId { get; set; }
        public string ToEmployeeName { get; set; } = null!;
        public List<TransferDocumentItemDto> Items { get; set; } = new();
    }

    public class TransferDocumentItemDto : BaseDto
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
    }
}
