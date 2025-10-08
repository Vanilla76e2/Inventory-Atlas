using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип оборудования.
    /// <para/>
    /// Используется для классификации техники в учёте.
    /// </summary>
    public enum EquipmentType
    {
        /// <summary>
        /// Настольный компьютер.
        /// </summary>
        [Display(Name = "Компьютер")]
        Computer = 1,

        /// <summary>
        /// Монитор или дисплей.
        /// </summary>
        [Display(Name = "Монитор")]
        Monitor = 2,

        /// <summary>
        /// Принтер, включая лазерные и струйные.
        /// </summary>
        [Display(Name = "Принтер")]
        Printer = 3,

        /// <summary>
        /// Сканер.
        /// </summary>
        [Display(Name = "Сканер")]
        Scanner = 4,

        /// <summary>
        /// Ноутбук.
        /// </summary>
        [Display(Name = "Ноутбук")]
        Laptop = 5,

        /// <summary>
        /// Планшет.
        /// </summary>
        [Display(Name = "Планшет")]
        Tablet = 6,

        /// <summary>
        /// Источник бесперебойного питания (ИБП).
        /// </summary>
        [Display(Name = "ИБП")]
        UPS = 7,

        /// <summary>
        /// Телефон или мобильное устройство.
        /// </summary>
        [Display(Name = "Телефон")]
        Phone = 8,

        /// <summary>
        /// Другое оборудование, не попадающее в стандартные категории.
        /// </summary>
        [Display(Name = "Другое")]
        Other = 99
    }
}
