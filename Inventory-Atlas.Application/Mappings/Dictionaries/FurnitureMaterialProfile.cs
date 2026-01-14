using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Application.Entities.Dictionaries;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class FurnitureMaterialProfile : Profile
    {
        public FurnitureMaterialProfile()
        {
            CreateMap<FurnitureMaterial, FurnitureMaterialDto>();
        }
    }
}
