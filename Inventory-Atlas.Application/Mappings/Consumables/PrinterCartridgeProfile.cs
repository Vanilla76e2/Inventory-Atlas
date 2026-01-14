using AutoMapper;
using Inventory_Atlas.Core.DTOs.Consumables;
using Inventory_Atlas.Application.Entities.Сonsumables;

namespace Inventory_Atlas.Application.Mappings.Consumables
{
    public class PrinterCartridgeProfile : Profile
    {
        public PrinterCartridgeProfile()
        {
            CreateMap<PrinterCartridge, PrinterCartridgeDto>();
        }
    }
}
