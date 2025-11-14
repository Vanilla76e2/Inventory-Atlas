using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class CustomFieldValueProfile : Profile
    {
        public CustomFieldValueProfile()
        {
            CreateMap<CustomFieldValue, CustomFieldValueDto>()
                .ForMember(dest => dest.InventoryItemId,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.FieldName,
                            opt => opt.MapFrom(src => src.FieldDefenition.FieldName));
        }
    }
}
