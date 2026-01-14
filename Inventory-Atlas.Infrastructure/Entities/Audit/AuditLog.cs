using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Audit
{
    [Table("AuditLogs", Schema = "Audit")]
    /// <summary>
    /// Сущность журнала событий.
    /// </summary>
    public class AuditLog : BaseEntity
    {
        /// <summary>
        /// Дата совершения действия.
        /// </summary>
        [Column("occurred_at")]
        public DateTime OccurredAt { get; set; }


        [Column("session_token")]
        public string? SessionToken { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }


        [Column("action_type")]
        public Core.Enums.ActionType ActionType { get; set; } = Core.Enums.ActionType.Unknown;

        [Column("target_type")]
        public string? TargetType { get; set; }

        [Column("target_id")]
        public string? TargetId { get; set; }


        /// <summary>
        /// Подробности действия.
        /// </summary>
        [Column("details", TypeName = "jsonb")]
        public string? Details { get; set; }


        [InverseProperty(nameof(AuditChange.AuditLog))]
        public virtual ICollection<AuditChange> Changes { get; set; } = new List<AuditChange>();
    }
}
