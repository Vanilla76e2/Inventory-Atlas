using AutoMapper;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Inventory;
using Inventory_Atlas.Application.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class MonitorProfile : Profile
    {
        public MonitorProfile()
        {
            CreateMap<Application.Entities.Technics.Monitor, MonitorDto>()
                .IncludeBase<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
