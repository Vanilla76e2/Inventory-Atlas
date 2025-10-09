using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Common
{
    public class DocumentDto : AuditableDto
    {
        public DateTime DocumentDate { get; set; }
        public string? DocumentName { get; set; }
        public string? Comment { get; set; }
        public DocumentStatus DocumentType { get; set; }
    }
}
