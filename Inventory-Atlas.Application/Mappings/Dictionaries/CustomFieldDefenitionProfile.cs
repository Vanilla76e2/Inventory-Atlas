using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class CustomFieldDefenitionProfile : Profile
    {
        public CustomFieldDefenitionProfile() 
        {
            CreateMap<CustomFieldDefenition, CustomFieldDefenitionDto>()
                .ForMember(dest => dest.CategoryName,
                            opt => opt.MapFrom(src => src.Category == null ? string.Empty : src.Category.Name));
        }
    }
}
