using Inventory_Atlas.Application.Entities.Audit;
using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Audit
{
    [Table("AuditCganges", Schema = "Audit")]
    public class AuditChange : BaseEntity
    {
        [Column("audit_log_id")]
        public int AuditLogId { get; set; }

        [ForeignKey(nameof(AuditLogId))]
        public AuditLog AuditLog { get; set; } = null!;

        [Column("entity_name")]
        public string? EntityName { get; set; }

        [Column("entity_id")]
        public string? EntityId { get; set; }


        [Column("property_name")]
        public string? PropertyName { get; set; }
        
        [Column("old_value")]
        public string? OldValue { get; set; }

        [Column("new_value")]
        public string? NewValue { get; set; }
    }
}
