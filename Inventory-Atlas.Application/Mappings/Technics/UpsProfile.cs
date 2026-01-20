using AutoMapper;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class UpsProfile : Profile
    {
        public UpsProfile()
        {
            CreateMap<UPS, UpsDto>()
                .IncludeBase<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
