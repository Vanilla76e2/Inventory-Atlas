using AutoMapper;
using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Application.Entities.Employees;

namespace Inventory_Atlas.Application.Mappings.Employees
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
