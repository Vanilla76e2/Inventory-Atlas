using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Application.Entities.Inventory;
using Inventory_Atlas.Application.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
