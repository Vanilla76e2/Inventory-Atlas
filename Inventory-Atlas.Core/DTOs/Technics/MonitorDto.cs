using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class MonitorDto : DeviceDto
    {
        public double? Diagonal { get; set; }
        public string? Resolution { get; set; }
        public int? RefreshRate { get; set; }
        public DisplayType? PanelType { get; set; }
        public short? Vga { get; set; }
        public short? Hdmi { get; set; }
        public short? DisplayPort { get; set; }
        public short? Dvi { get; set; }
        public int TotalPorts => (Vga ?? 0) + (Hdmi ?? 0) + (DisplayPort ?? 0) + (Dvi ?? 0);
    }
}
