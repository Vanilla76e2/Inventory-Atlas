using AutoMapper;
using Inventory_Atlas.Core.DTOs.Audit;
using Inventory_Atlas.Application.Entities.Audit;

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
        }
    }
}
