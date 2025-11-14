using AutoMapper;
using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class PrinterProfile : Profile
    {
        public PrinterProfile()
        {
            CreateMap<Printer, PrinterDto>()
                .IncludeBase<Equipment, EquipmentDto>()
                .IncludeBase<InventoryItem, InventoryItemDto>();
        }
    }
}
