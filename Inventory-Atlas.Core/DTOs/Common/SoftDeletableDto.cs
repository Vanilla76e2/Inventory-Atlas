namespace Inventory_Atlas.Core.DTOs.Common
{
    public class SoftDeletableDto : AuditableDto
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
