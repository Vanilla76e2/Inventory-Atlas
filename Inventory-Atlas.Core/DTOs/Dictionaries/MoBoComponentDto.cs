using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class MoBoComponentDto : ComputerComponentDto
    {
        public int MoBoId { get; set; }
        public string Vendor { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Socket { get; set; }
        public string? Chipset { get; set; }
        public Enums.MoBoFormFactor FormFactor { get; set; }
        public short? RamSlots { get; set; }
        public short? MaxRamGB { get; set; }
        public short? PcieSlots { get; set; }
        public short? M2Slots { get; set; }
    }
}
