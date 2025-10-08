using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Статус инвентарного объекта.
    /// <para/>
    /// Используется для отслеживания состояния оборудования или других ресурсов.
    /// </summary>
    public enum InventoryStatus
    {
        /// <summary>
        /// В работе — закреплено за пользователем или рабочим местом.
        /// </summary>
        [Display(Name = "В работе")]
        InUse = 1,

        /// <summary>
        /// На складе — готово к выдаче.
        /// </summary>
        [Display(Name = "На складе")]
        Stored = 2,

        /// <summary>
        /// В ремонте — оборудование временно не доступно из-за обслуживания или поломки.
        /// </summary>
        [Display(Name = "В ремонте")]
        UnderRepair = 3,

        /// <summary>
        /// Под списание — отмечено для списания, готово к исключению из эксплуатации.
        /// </summary>
        [Display(Name = "Под списание")]
        ToBeWrittenOff = 4,

        /// <summary>
        /// Списано — уже исключено из эксплуатации.
        /// </summary>
        [Display(Name = "Списано")]
        WrittenOff = 5,

        /// <summary>
        /// Резерв — выделено под будущую задачу или сотрудника.
        /// </summary>
        [Display(Name = "Резерв")]
        Reserved = 6,

        /// <summary>
        /// Демонстрационное / тестовое — стенды, демо-оборудование.
        /// </summary>
        [Display(Name = "Демо")]
        Demo = 7
    }
}
