using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class InventoryCategoryProfile : Profile
    {
        public InventoryCategoryProfile()
        {
            CreateMap<InventoryCategory, InventoryCategoryDto>();
        }
    }
}
