using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.References
{
    public class MoBoDto : BaseDto
    {
        public string Vendor { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Socket { get; set; }
        public string? Chipset { get; set; }
        public MoBoFormFactor FormFactor { get; set; }
        public short? RamSlots { get; set; }
        public short? MaxRamGB { get; set; }
        public short? PcieSlots { get; set; }
        public short? M2Slots { get; set; }

        public List<int>? ComponentIds { get; set; }
    }
}
