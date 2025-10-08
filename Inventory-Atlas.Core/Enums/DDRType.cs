using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип оперативной памяти.
    /// <para/>
    /// Используется для компонентов типа RAM.
    /// </summary>
    public enum DDRType
    {
        [Display(Name = "DDR1")]
        DDR1 = 1,

        [Display(Name = "DDR2")]
        DDR2 = 2,

        [Display(Name = "DDR3")]
        DDR3 = 3,

        [Display(Name = "DDR4")]
        DDR4 = 4,

        [Display(Name = "DDR5")]
        DDR5 = 5,

        [Display(Name = "Другое")]
        Other = 99
    }
}
