using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class RAMComponentDto : ComputerComponentDto
    {
        public Enums.DDRType DdrType { get; set; }
        public short Size { get; set; }
        public int? Frequency { get; set; }
    }
}
