using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Technics.Components;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Entities.Technics.Components;

namespace Inventory_Atlas.Application.Mappings.Technics.Components
{
    public class MoboComponentProfile : Profile
    {
        public MoboComponentProfile()
        {
            CreateMap<MoBoComponent, MoBoComponentDto>()
                .IncludeBase<ComputerComponent, ComputerComponentDto>()
                .ForMember(dest => dest.Vendor,
                            opt => opt.MapFrom(src => src.MoBoReference.Vendor))
                .ForMember(dest => dest.Model,
                            opt => opt.MapFrom(src => src.MoBoReference.Model))
                .ForMember(dest => dest.Socket,
                            opt => opt.MapFrom(src => src.MoBoReference.Socket))
                .ForMember(dest => dest.Chipset,
                            opt => opt.MapFrom(src => src.MoBoReference.Chipset))
                .ForMember(dest => dest.FormFactor,
                            opt => opt.MapFrom(src => src.MoBoReference.FormFactor))
                .ForMember(dest => dest.RamSlots,
                            opt => opt.MapFrom(src => src.MoBoReference.RamSlots))
                .ForMember(dest => dest.PcieSlots,
                            opt => opt.MapFrom(src => src.MoBoReference.PcieSlots))
                .ForMember(dest => dest.M2Slots,
                            opt => opt.MapFrom(src => src.MoBoReference.M2Slots));
        }
    }
}
