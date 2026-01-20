using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Application.Mappings.Inventory
{
    public class InventoryItemProfile : Profile
    {
        public InventoryItemProfile()
        {
            CreateMap<InventoryItem, InventoryItemDto>()
                .ForMember(dest => dest.ResponsibleName,
                            opt => opt.MapFrom(src => src.Responsible == null ? string.Empty
                                                        : src.Responsible.Employee == null ? string.Empty
                                                        : src.Responsible.Employee.FullName))
                .ForMember(dest => dest.Photos,
                            opt => opt.MapFrom(src => src.InventoryItemPhotos))
                .ForMember(dest => dest.CategoryName,
                            opt => opt.MapFrom(src => src.Category == null ? string.Empty : src.Category.Name))
                .Include<Computer,InventoryItemDto>();

            CreateMap<Computer, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Equipment, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Laptop, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Infrastructure.Entities.Technics.Monitor, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<NetworkDevice, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Phone, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Printer, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Scanner, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Software, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Tablet, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<UPS, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();

            CreateMap<Furniture, InventoryItemDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
