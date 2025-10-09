using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class GPUComponentDto : ComputerComponentDto
    {
        public int GpuId { get; set; }
        public string Vendor { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int MemorySize { get; set; }
        public Enums.GpuMemoryType MemoryType { get; set; }
        public short? Vga { get; set; }
        public short? Hdmi { get; set; }
        public short? DisplayPort { get; set; }
        public short? Dvi { get; set; }
        public int TotalPorts => (Vga ?? 0) + (Hdmi ?? 0) + (DisplayPort ?? 0) + (Dvi ?? 0);
    }
}
