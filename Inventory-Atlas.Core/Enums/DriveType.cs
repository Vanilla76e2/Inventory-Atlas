using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип накопителя.
    /// <para/>
    /// Используется для описания дисков в компьютерах, ноутбуках и других устройствах.
    /// </summary>
    public enum DriveType
    {
        /// <summary>
        /// HDD — традиционный жесткий диск с магнитными пластинами.
        /// </summary>
        [Display(Name = "HDD")]
        HDD = 1,

        /// <summary>
        /// SSD — твердотельный накопитель на основе флеш-памяти, быстрее HDD.
        /// </summary>
        [Display(Name = "SSD")]
        SSD = 2,

        /// <summary>
        /// NVMe — современный высокоскоростной SSD с интерфейсом NVMe (через PCIe).
        /// </summary>
        [Display(Name = "NVMe")]
        NVMe = 3,

        /// <summary>
        /// Другое — нестандартный или неизвестный тип накопителя.
        /// </summary>
        [Display(Name = "Другое")]
        Other = 99
    }
}
