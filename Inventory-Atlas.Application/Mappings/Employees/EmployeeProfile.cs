using AutoMapper;
using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Infrastructure.Entities.Employees;

namespace Inventory_Atlas.Infrastructure.Mappings.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName,
                            opt => opt.MapFrom(src => src.Department == null ? string.Empty : src.Department.Name));

            CreateMap<Employee, EmployeeListDto>()
                .ForMember(dest => dest.DepartmentName,
                            opt => opt.MapFrom(src => src.Department == null ? string.Empty : src.Department.Name));
        }
    }
}
