using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Infrastructure.Mappings.Inventory
{
    public class FurnitureProfile : Profile
    {
        public FurnitureProfile()
        {
            CreateMap<FurnitureMaterialAssignment, FurnitureMaterialAssignmentDto>()
                .ForMember(dest => dest.MaterialName,
                            opt => opt.MapFrom(src => src.FurnitureMaterial.Name));

            CreateMap<FurnitureMaterialAssignment, FurnitureMaterialAssignmentListDto>()
                .ForMember(dest => dest.MaterialName,
                            opt => opt.MapFrom(src => src.FurnitureMaterial.Name));

            CreateMap<Furniture, FurnitureDto>()
                .ForMember(dest => dest.FurnitureTypeName,
                            opt => opt.MapFrom(src => src.FurnitureType.Name))
                .ForMember(dest => dest.Materials,
                            opt => opt.MapFrom(src => src.Materials));
        }
    }
}
