using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип компьютерного компонента.
    /// </summary>
    public enum ComponentType
    {
        /// <summary>
        /// Центральный процессор.
        /// </summary>
        [Display(Name = "Процессор")]
        CPU = 1,

        /// <summary>
        /// Оперативная память (RAM).
        /// </summary>
        [Display(Name = "Оперативная память")]
        RAM = 2,

        /// <summary>
        /// Дисковая память (HDD, SSD, NVMe).
        /// </summary>
        [Display(Name = "Диск")]
        Drive = 3,

        /// <summary>
        /// Видеокарта.
        /// </summary>
        [Display(Name = "Видеокарта")]
        GPU = 4,

        /// <summary>
        /// Звуковая карта.
        /// </summary>
        [Display(Name = "Звуковая карта")]
        SoundCard = 5,

        /// <summary>
        /// Сетевая карта.
        /// </summary>
        [Display(Name = "Сетевая карта")]
        NetCard = 6,

        /// <summary>
        /// Прочие компоненты, не отнесённые к конкретной категории.
        /// </summary>
        [Display(Name = "Другое")]
        Other = 99
    }
}
