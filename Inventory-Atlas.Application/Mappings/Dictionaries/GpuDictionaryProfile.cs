using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Application.Entities.References;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class GpuDictionaryProfile : Profile
    {
        public GpuDictionaryProfile()
        {
            CreateMap<GpuDictionary, GPUDto>();
        }
    }
}
