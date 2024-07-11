using EmployeeManagementAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string? Name { get; set; }
        public string Surame { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Position Position { get; set; }
        public int? PositionId { get; set; }
        public int? ManagerId { get; set; }
        public ICollection<Department>? Departments { get; set; }
        public ICollection<EmployeePosition>? EmployeePositions { get; set; }
        public ICollection<DepartmentEmployees>? DepartmentEmployees { get; set; }
    }
}
