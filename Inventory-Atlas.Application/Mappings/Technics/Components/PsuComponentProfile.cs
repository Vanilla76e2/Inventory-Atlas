using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Technics.Components;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;

namespace Inventory_Atlas.Infrastructure.Mappings.Technics.Components
{
    public class PsuComponentProfile : Profile
    {
        public PsuComponentProfile()
        {
            CreateMap<PsuComponent, PsuComponentDto>()
                .IncludeBase<ComputerComponent, ComputerComponentDto>();
        }
    }
}
