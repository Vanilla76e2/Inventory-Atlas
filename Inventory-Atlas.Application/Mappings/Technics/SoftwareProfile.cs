using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Infrastructure.Mappings.Technics
{
    public class SoftwareProfile : Profile
    {
        public SoftwareProfile()
        {
            CreateMap<Software, SoftwareDto>()
                .IncludeBase<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
