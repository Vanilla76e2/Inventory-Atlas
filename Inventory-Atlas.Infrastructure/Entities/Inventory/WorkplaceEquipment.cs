using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics
{
    /// <summary>
    /// Связь рабочего места с оборудованием.
    /// <para/>
    /// Сущность указывает, какое оборудование закреплено за конкретным рабочим местом.
    /// </summary>
    [Table("WorkplaceEquipmentRepository", Schema = "Inventory")]
    public class WorkplaceEquipment : BaseEntity
    {
        /// <summary>
        /// Идентификатор рабочего места.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("workplace_id")]
        public int WorkplaceId { get; set; }

        /// <summary>
        /// Навигационное свойство на рабочее место.
        /// <para/>
        /// Тип: <see cref="Workplace"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(WorkplaceId))]
        public virtual Workplace Workplace { get; set; } = null!;

        /// <summary>
        /// Идентификатор оборудования.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("equipment_id")]
        public int EquipmentId { get; set; }

        /// <summary>
        /// Навигационное свойство на оборудование.
        /// <para/>
        /// Тип: <see cref="Equipment"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(EquipmentId))]
        public virtual Equipment Equipment { get; set; } = null!;
    }
}
