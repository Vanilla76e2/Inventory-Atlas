namespace Inventory_Atlas.Core.DTOs.Common
{
    public class AuditableDto : BaseDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
