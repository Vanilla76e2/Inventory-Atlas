using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Audit
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
        [Column("action_date")]
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Подробности действия.
        /// </summary>
        [Column("details", TypeName = "jsonb")]
        public string? Details { get; set; }
    }
}
