using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Technics.Components;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Entities.Technics.Components;

namespace Inventory_Atlas.Application.Mappings.Technics.Components
{
    public class RamComponentProfile : Profile
    {
        public RamComponentProfile()
        {
            CreateMap<RamComponent, RamComponentDto>()
                .IncludeBase<ComputerComponent, ComputerComponentDto>();
        }
    }
}
