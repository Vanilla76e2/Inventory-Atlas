using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность оборудования.
    /// <para/>
    /// Является устройством (<see cref="DeviceEntity"/>), может быть связанным с рабочими местами.
    /// </summary>
    [Table("Equipment", Schema = "Technics")]
    public class Equipment : InventoryItem
    {
        /// <summary>
        /// Коллекция связей оборудования с рабочими местами.
        /// <para/>
        /// Тип: <see cref="ICollection{T}"/> с элементами <see cref="WorkplaceEquipment"/>.
        /// <para/>
        /// Не может быть <see langword="null"/> (инициализируется пустым списком).
        /// </summary>
        [InverseProperty(nameof(WorkplaceEquipment.Equipment))]
        public virtual ICollection<WorkplaceEquipment> WorkplaceEquipments { get; set; } = new List<WorkplaceEquipment>();

        /// <summary>
        /// Коллекция записей журнала обслуживания, связанных с оборудованием.
        /// <para/>
        /// Тип: <see cref="ICollection{MaintenanceLog}"/>.
        /// <para/>
        /// Используется для хранения истории технического обслуживания оборудования.
        /// </summary>
        [InverseProperty(nameof(MaintenanceLog.Device))]
        public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
    }
}
