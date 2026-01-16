using AutoMapper;
using Inventory_Atlas.Core.DTOs.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Inventory;

namespace Inventory_Atlas.Infrastructure.Mappings.Inventory
{
    public class WorkplaceProfile : Profile
    {
        public WorkplaceProfile()
        {
            CreateMap<WorkplaceEquipment, WorkplaceEquipmentDto>()
                .ForMember(dest => dest.Workplace,
                            opt => opt.MapFrom(src => src.Workplace))
                .ForMember(dest => dest.Equipment,
                            opt => opt.MapFrom(src => src.Equipment));

            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee == null ? string.Empty : src.Employee.ShortName))
                .ForMember(dest => dest.Equipments,
                            opt => opt.MapFrom(src => src.WorkplaceEquipments));
        }
    }
}
