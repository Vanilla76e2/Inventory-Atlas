using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Запись о проведённом обслуживании устройства.
    /// <para/>
    /// Содержит информацию о дате обслуживания, типе обслуживания,
    /// сотруднике, выполнившем обслуживание, комментариях и связанном устройстве.
    /// </summary>
    [Table("MaintenanceLogs", Schema = "Technics")]
    public class MaintenanceLog : BaseEntity
    {
        /// <summary>
        /// Идентификатор обслуживаемого устройства.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("device_id")]
        public int DeviceId { get; set; }

        /// <summary>
        /// Навигационное свойство на устройство.
        /// <para/>
        /// Тип: <see cref="DeviceEntity"/>.
        /// <para/>
        /// Обеспечивает доступ к объекту устройства, к которому относится запись обслуживания.
        /// </summary>
        [ForeignKey(nameof(DeviceId))]
        public Equipment Device { get; set; } = null!;

        /// <summary>
        /// Дата проведения обслуживания.
        /// <para/>
        /// Тип: <see cref="DateTime"/>.
        /// </summary>
        [Column("maintenance_date")]
        public DateTime MaintenanceDate { get; set; }

        /// <summary>
        /// Тип проведённого обслуживания.
        /// <para/>
        /// Тип: <see cref="MaintenanceType"/>.
        /// </summary>
        [Column("maintenance_type")]
        public MaintenanceType MaintenanceType { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, который выполнил обслуживание.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("performed_by")]
        public int PerformedBy { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника, который выполнил обслуживание.
        /// <para/>
        /// Тип: <see cref="Employees.Employee"/>.
        /// <para/>
        /// Позволяет получить информацию о сотруднике, который провёл обслуживание.
        /// </summary>
        [ForeignKey(nameof(PerformedBy))]
        public virtual Employees.Employee Employee { get; set; } = null!;

        /// <summary>
        /// Комментарий к записи обслуживания.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может содержать дополнительные сведения о проведённом обслуживании.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }
    }
}
