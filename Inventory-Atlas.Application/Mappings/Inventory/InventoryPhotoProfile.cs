using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Application.Mappings.Inventory
{
    public class InventoryPhotoProfile : Profile
    {
        public InventoryPhotoProfile()
        {
            CreateMap<InventoryPhoto, InventoryPhotoDto>();
        }
    }
}
