using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class NetworkComponentDto : ComputerComponentDto
    {
        public string Model { get; set; } = null!;
        public string? MACAddress { get; set; }
        public bool Optical { get; set; }
        public int? Speed { get; set; }
    }
}
