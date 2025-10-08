using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Форм-фактор материнской платы.
    /// </summary>
    public enum MoBoFormFactor
    {
        [Display(Name = "ATX")]
        ATX = 1,

        [Display(Name = "MicroATX")]
        MicroATX = 2,

        [Display(Name = "MiniITX")]
        MiniITX = 3,

        [Display(Name = "EATX")]
        EATX = 4,

        [Display(Name = "XLATX")]
        XLATX = 5,

        [Display(Name = "FlexATX")]
        FlexATX = 6,

        [Display(Name = "BTX")]
        BTX = 7,

        [Display(Name = "ITX")]
        ITX = 8,

        [Display(Name = "NanoITX")]
        NanoITX = 9,

        [Display(Name = "PicoITX")]
        PicoITX = 10,

        [Display(Name = "Другое")]
        Other = 99
    }
}
