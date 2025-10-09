using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class PSUComponentDto : ComputerComponentDto
    {
        public int Wattage { get; set; }
    }
}
