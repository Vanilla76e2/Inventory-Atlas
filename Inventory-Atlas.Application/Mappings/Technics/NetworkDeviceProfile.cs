using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class NetworkDeviceProfile : Profile
    {
        public NetworkDeviceProfile()
        {
            CreateMap<WiFiNetworkJsonModel, WiFiNetworkPublicModel>()
                .ForMember(dest => dest.Ssid, opt => opt.MapFrom(src => src.Ssid))
                .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band));

            CreateMap<NetworkDevice, NetworkDeviceDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>()
                .ForMember(dest => dest.WifiNetworks, opt => opt.MapFrom(src => src.WiFiNetworksJson));

            CreateMap<NetworkDevice, NetworkDeviceDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>()
                .ForMember(dest => dest.WifiNetworks, opt => opt.MapFrom(src => src.WiFiNetworksJson));
        }
    }
}
