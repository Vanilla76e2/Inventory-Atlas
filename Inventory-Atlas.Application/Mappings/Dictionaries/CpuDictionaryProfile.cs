using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;

namespace Inventory_Atlas.Infrastructure.Mappings.Dictionaries
{
    public class CpuDictionaryProfile : Profile
    {
        public CpuDictionaryProfile()
        {
            CreateMap<CpuDictionary, CPUDto>();
        }
    }
}
