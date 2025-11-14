using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.References;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class CpuDictionaryProfile : Profile
    {
        public CpuDictionaryProfile()
        {
            CreateMap<CpuDictionary, CPUDto>();
        }
    }
}
