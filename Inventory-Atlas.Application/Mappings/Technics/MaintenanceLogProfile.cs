using AutoMapper;
using Inventory_Atlas.Core.DTOs.Technics;
using Inventory_Atlas.Application.Entities.Technics;

namespace Inventory_Atlas.Application.Mappings.Technics
{
    public class MaintenanceLogProfile : Profile
    {
        public MaintenanceLogProfile()
        {
            CreateMap<MaintenanceLog, MaintenanceLogDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee == null ? string.Empty : src.Employee.ShortName));
        }
    }
}
