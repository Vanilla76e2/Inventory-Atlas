using AutoMapper;
using Inventory_Atlas.Core.DTOs.Dictionaries;
using Inventory_Atlas.Infrastructure.Entities.References;

namespace Inventory_Atlas.Application.Mappings.Dictionaries
{
    public class MoBoDictionaryProfile : Profile
    {
        public MoBoDictionaryProfile()
        {
            CreateMap<MoBoDictionary, MoBoDto>();
        }
    }
}
