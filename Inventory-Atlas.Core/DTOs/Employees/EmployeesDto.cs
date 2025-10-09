using Inventory_Atlas.Core.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    public class EmployeeDto : SoftDeletableDto
    {
        public string Surname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? Position { get; set; }
        public string? Comment { get; set; }
        public bool IsResponsible { get; set; }
        public string Fullname => string.IsNullOrWhiteSpace(Patronymic)
       ? $"{Surname} {Firstname}"
       : $"{Surname} {Firstname} {Patronymic}";
    }

    public class EmployeeSummaryDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
    }
}
