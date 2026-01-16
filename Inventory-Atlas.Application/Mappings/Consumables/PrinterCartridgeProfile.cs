using AutoMapper;
using Inventory_Atlas.Core.DTOs.Consumables;
using Inventory_Atlas.Infrastructure.Entities.Consumables;

namespace Inventory_Atlas.Infrastructure.Mappings.Consumables
{
    public class PrinterCartridgeProfile : Profile
    {
        public PrinterCartridgeProfile()
        {
            CreateMap<PrinterCartridge, PrinterCartridgeDto>();
        }
    }
}
