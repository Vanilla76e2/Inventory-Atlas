using AutoMapper;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Mappings.Users
{
    public class FavouriteProfile : Profile
    {
        public FavouriteProfile()
        {
            CreateMap<Favourite, FavouriteDto>()
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.InventoryNumber,
                            opt => opt.MapFrom(src => src.Item.InventoryNumber))
                .ForMember(dest => dest.Location,
                            opt => opt.MapFrom(src => src.Item.Location))
                .ForMember(dest => dest.Status,
                            opt => opt.MapFrom(src => src.Item.Status))
                .ForMember(dest => dest.Comment,
                            opt => opt.MapFrom(src => src.Item.Comment))
                .ForMember(dest => dest.FavouritedAt,
                            opt => opt.MapFrom(src => src.FavouritedAt));
        }
    }
}
