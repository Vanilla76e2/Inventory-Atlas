using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;

namespace Inventory_Atlas.Infrastructure.Mappings.Dictionaries
{
    public class IpDictionaryProfile : Profile
    {
        public IpDictionaryProfile()
        {
            CreateMap<IpDictionary, IpDictionaryDto>();
        }
    }
}
