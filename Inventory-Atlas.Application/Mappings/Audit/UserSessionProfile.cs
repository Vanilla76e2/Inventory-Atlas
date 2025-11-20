using AutoMapper;
using Inventory_Atlas.Core.DTOs.Audit;
using Inventory_Atlas.Infrastructure.Entities.Audit;

namespace Inventory_Atlas.Application.Mappings.Audit
{
    public class UserSessionProfile : Profile
    {
        public UserSessionProfile()
        {
            // Полная DTO с логами
            CreateMap<UserSession, UserSessionDto>();

            // Упрощённая DTO без логов
            CreateMap<UserSession, UserSessionListDto>();

            // DTO для сервисного слоя
            CreateMap<UserSession, UserSeesionServiceDto>()
                .ForMember(dst => dst.RoleName,
                            opt => opt.MapFrom(src => src.UserProfile == null ? null : src.UserProfile.Role.Name))
                .ForMember(dst => dst.PermissionJson,
                            opt => opt.MapFrom(src => src.UserProfile == null ? null : src.UserProfile.Role.PermissionJson));
        }
    }
}
