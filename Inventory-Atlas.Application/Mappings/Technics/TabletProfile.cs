using AutoMapper;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Inventory;
using Inventory_Atlas.Application.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class TabletProfile : Profile
    {
        public TabletProfile()
        {
            CreateMap<Tablet, TabletDto>()
                .IncludeBase<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
