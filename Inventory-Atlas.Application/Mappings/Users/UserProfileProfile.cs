using AutoMapper;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Mappings.Users
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee == null ? string.Empty : src.Employee.ShortName))
                .ForMember(dest => dest.RoleName,
                            opt => opt.MapFrom(src => src.Role.Name));

            CreateMap<UserProfile, UserProfileUpdateDto>();
        }

        
    }
}
