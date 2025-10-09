using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Documents
{
    public class WriteOffDocumentDto : DocumentDto
    {
        public string? Reason { get; set; }
        public List<WriteOffDocumentItemDto> Items { get; set; } = new();
    }

    public class WriteOffDocumentItemDto : BaseDto
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
    }
}
