using AutoMapper;
using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Infrastructure.Entities.Employees;

namespace Inventory_Atlas.Infrastructure.Mappings.Employees
{
    public class MateriallyResposibleProfile : Profile
    {
        public MateriallyResposibleProfile()
        {
            CreateMap<MateriallyResponsible, MateriallyResponsibleDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee == null ? string.Empty : src.Employee.FullName))
                .ForMember(dest => dest.Items,
                            opt => opt.MapFrom(src => src.Items));

            CreateMap<MateriallyResponsible, MateriallyResponsibleListDto>()
                .ForMember(dest => dest.EmployeeName,
                            opt => opt.MapFrom(src => src.Employee == null ? string.Empty : src.Employee.ShortName));
        }
    }
}
