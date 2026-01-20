using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Technics.Components;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;

namespace Inventory_Atlas.Application.Mappings.Technics.Components
{
    public class CpuComponentProfile : Profile
    {
        public CpuComponentProfile()
        {
            CreateMap<CpuComponent, CpuComponentDto>()
                .IncludeBase<ComputerComponent, ComputerComponentDto>()
                .ForMember(dest => dest.CpuModel,
                            opt => opt.MapFrom(src => src.CPUReference.Model))
                .ForMember(dest => dest.CpuVendor,
                            opt => opt.MapFrom(src => src.CPUReference.Vendor))
                .ForMember(dest => dest.CoreCount,
                            opt => opt.MapFrom(src => src.CPUReference.CoreCount))
                .ForMember(dest => dest.ThreadCount,
                            opt => opt.MapFrom(src => src.CPUReference.ThreadCount))
                .ForMember(dest => dest.Clock,
                            opt => opt.MapFrom(src => src.CPUReference.Clock))
                .ForMember(dest => dest.Socket,
                            opt => opt.MapFrom(src => src.CPUReference.Socket));
        }
    }
}
