using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип обслуживания или действия с оборудованием.
    /// </summary>
    public enum MaintenanceType
    {
        /// <summary>
        /// Плановое обслуживание — регулярные профилактические работы для поддержания оборудования в рабочем состоянии.
        /// </summary>
        [Display(Name = "Плановое обслуживание")]
        Scheduled = 1,

        /// <summary>
        /// Ремонт — восстановление работоспособности оборудования после поломки или сбоя.
        /// </summary>
        [Display(Name = "Ремонт")]
        Repair = 2,

        /// <summary>
        /// Проверка — инспекция оборудования без ремонта, оценка состояния.
        /// </summary>
        [Display(Name = "Проверка")]
        Inspection = 3,

        /// <summary>
        /// Модернизация — обновление оборудования, установка новых компонентов или функций.
        /// </summary>
        [Display(Name = "Модернизация")]
        Upgrade = 4,

        /// <summary>
        /// Замена картриджа — специфическое обслуживание принтеров.
        /// </summary>
        [Display(Name = "Замена картриджа")]
        CartridgeReplacement = 5,

        /// <summary>
        /// Чистка — удаление пыли и загрязнений, поддержка чистоты оборудования.
        /// </summary>
        [Display(Name = "Чистка")]
        Cleaning = 6
    }
}
