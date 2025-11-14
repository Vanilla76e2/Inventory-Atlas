using AutoMapper;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Mappings.Users
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.UserCount,
                            opt => opt.MapFrom(src => src.UserProfiles.Count()));

        }
    }
}
