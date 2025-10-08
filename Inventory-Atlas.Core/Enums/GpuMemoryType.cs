using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип видеопамяти графического процессора (GPU).
    /// <para/>
    /// Используется для указания стандарта и технологии памяти видеокарты.
    /// </summary>
    public enum GpuMemoryType
    {
        [Display(Name = "GDDR3")]
        GDDR3 = 1,

        [Display(Name = "GDDR5")]
        GDDR5 = 2,

        [Display(Name = "GDDR5X")]
        GDDR5X = 3,

        [Display(Name = "GDDR6")]
        GDDR6 = 4,

        [Display(Name = "GDDR6X")]
        GDDR6X = 5,

        [Display(Name = "HBM")]
        HBM = 6,

        [Display(Name = "HBM2")]
        HBM2 = 7,

        [Display(Name = "HBM2E")]
        HBM2E = 8,

        [Display(Name = "HBM3")]
        HBM3 = 9,

        [Display(Name = "Другое")]
        Other = 99
    }
}
