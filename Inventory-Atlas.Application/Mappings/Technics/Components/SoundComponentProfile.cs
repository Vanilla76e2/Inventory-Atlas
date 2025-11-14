using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Core.DTOs.Technics.Components;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Technics.Components;

namespace Inventory_Atlas.Application.Mappings.Technics.Components
{
    public class SoundComponentProfile : Profile
    {
        public SoundComponentProfile()
        {
            CreateMap<SoundComponent, SoundComponentDto>()
                .IncludeBase<ComputerComponent, ComputerComponentDto>();
        }
    }
}
