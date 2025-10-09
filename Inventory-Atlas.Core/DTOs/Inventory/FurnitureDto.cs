using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    public class FurnitureDto : InventoryItemDto
    {
        public int FurnitureTypeId { get; set; }
        public string FurnitureTypeName { get; set; } = null!;
        public string? Dimensions { get; set; }
        public double Weight { get; set; }
        public FurnitureOrientation Orientation { get; set; }

        public List<FurnitureMaterialAssignmentDto>? Materials { get; set; }
    }

    public class FurnitureMaterialAssignmentDto : BaseDto
    {
        public int FurnitureId { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; } = null!;
    }

    public class FurnitureMaterialDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public List<int>? FurnitureIds { get; set; }
    }

    public class FurnitureTypeDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public List<int>? FurnitureIds { get; set; }
    }
}
