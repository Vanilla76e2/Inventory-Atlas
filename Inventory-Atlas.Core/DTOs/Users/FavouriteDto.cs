using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Users
{
    public class FavouriteDto : BaseDto
    {
        public long? InventoryNumber { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public InventoryStatus Status { get; set; }
        public string? Comment { get; set; }
        public DateTime FavouritedAt { get; set; }
    }
}
