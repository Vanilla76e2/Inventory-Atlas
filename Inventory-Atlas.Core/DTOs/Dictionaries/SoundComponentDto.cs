using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class SoundComponentDto : ComputerComponentDto
    {
        public string Model { get; set; } = null!;
        public short? Channels { get; set; }
        public bool IsExternal { get; set; }
    }
}
