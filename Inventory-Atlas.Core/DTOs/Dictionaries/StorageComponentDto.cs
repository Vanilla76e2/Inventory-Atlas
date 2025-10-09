using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class StorageComponentDto : ComputerComponentDto
    {
        public Enums.DriveType StorageType { get; set; }
        public int Capacity { get; set; }
    }
}
