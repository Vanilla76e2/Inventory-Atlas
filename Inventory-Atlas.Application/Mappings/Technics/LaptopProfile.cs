using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Application.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class LaptopProfile : Profile
    {
        public LaptopProfile()
        {
            CreateMap<Laptop, LaptopDto>()
                .ForMember(dest => dest.IpAddress,
                            opt => opt.MapFrom(src => src.IpAddress == null ? string.Empty : src.IpAddress.ToString()));
        }
    }
}
