using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Technics.Components;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;

namespace Inventory_Atlas.Infrastructure.Mappings.Technics.Components
{
    public class GpuComponentProfile : Profile
    {
        public GpuComponentProfile()
        {
            CreateMap<GpuComponent, GpuComponentDto>()
                .IncludeBase<ComputerComponent, ComputerComponentDto>()
                .ForMember(dest => dest.Vendor,
                            opt => opt.MapFrom(src => src.GPUReference.Vendor))
                .ForMember(dest => dest.Model,
                            opt => opt.MapFrom(src => src.GPUReference.Model))
                .ForMember(dest => dest.MemorySize,
                            opt => opt.MapFrom(src => src.GPUReference.MemorySize))
                .ForMember(dest => dest.MemoryType,
                            opt => opt.MapFrom(src => src.GPUReference.MemoryType))
                .ForMember(dest => dest.Vga,
                            opt => opt.MapFrom(src => src.GPUReference.Vga))
                .ForMember(dest => dest.Dvi,
                            opt => opt.MapFrom(src => src.GPUReference.Dvi))
                .ForMember(dest => dest.Hdmi,
                            opt => opt.MapFrom(src => src.GPUReference.Hdmi))
                .ForMember(dest => dest.DisplayPort,
                            opt => opt.MapFrom(src => src.GPUReference.DisplayPort));
        }
    }
}
