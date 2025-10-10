using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Core.DTOs.Inventory;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для оборудования, расширяющее элемент инвентаря.
    /// <para/>
    /// Тип: <see cref="EquipmentDto"/>
    /// <para/>
    /// Наследуется от <see cref="InventoryItemDto"/> и содержит информацию о привязках к рабочим местам и журналах обслуживания.
    /// </summary>
    public class EquipmentDto : InventoryItemDto
    {
        /// <summary>
        /// Список привязок оборудования к рабочим местам.
        /// <para/>
        /// Тип: <see cref="List{WorkplaceEquipmentDto}"/>
        /// <para/>
        /// Инициализируется пустым списком по умолчанию.
        /// </summary>
        public List<WorkplaceEquipmentDto> WorkplaceEquipments { get; set; } = new();

        /// <summary>
        /// Журналы технического обслуживания оборудования.
        /// <para/>
        /// Тип: <see cref="List{MaintenanceLogDto}"/>
        /// <para/>
        /// Инициализируется пустым списком по умолчанию.
        /// </summary>
        public List<MaintenanceLogDto> MaintenanceLogs { get; set; } = new();
    }
}
