using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class ComputerProfile : Profile
    {
        public ComputerProfile()
        {
            CreateMap<ComputerComponent, ComputerComponentDto>()
                .IncludeAllDerived();

            CreateMap<Computer, ComputerDto>()
                .ForMember(dest => dest.Components,
                            opt => opt.MapFrom(src => src.ComputerComponents))
                .IncludeBase<Equipment,EquipmentDto>()
                .IncludeBase<InventoryItem,InventoryItemDto>();

            CreateMap<Computer, ComputerDetailDto>()
                .ForMember(dest => dest.Components,
                            opt => opt.MapFrom(src => src.ComputerComponents))
                .ForMember(dest => dest.WorkplaceEquipments,
                            opt => opt.MapFrom(src => src.WorkplaceEquipments))
                .ForMember(dest => dest.MaintenanceLogs,
                            opt => opt.MapFrom(src => src.MaintenanceLogs))
                .IncludeBase<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
