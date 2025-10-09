using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class OtherComponentDto : ComputerComponentDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
