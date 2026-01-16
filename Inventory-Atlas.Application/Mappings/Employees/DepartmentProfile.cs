using AutoMapper;
using Inventory_Atlas.Core.DTOs.Employees;
using Inventory_Atlas.Infrastructure.Entities.Employees;

namespace Inventory_Atlas.Infrastructure.Mappings.Employees
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
