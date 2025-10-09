using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.References
{
    public class GPUDto : BaseDto
    {
        public string Vendor { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int MemorySize { get; set; } // MB
        public GpuMemoryType MemoryType { get; set; }
        public short? Vga { get; set; }
        public short? Hdmi { get; set; }
        public short? DisplayPort { get; set; }
        public short? Dvi { get; set; }

        // Рассчитанное поле
        public int TotalPorts => (Vga ?? 0) + (Hdmi ?? 0) + (DisplayPort ?? 0) + (Dvi ?? 0);

        public List<int>? ComponentIds { get; set; }
    }
}
