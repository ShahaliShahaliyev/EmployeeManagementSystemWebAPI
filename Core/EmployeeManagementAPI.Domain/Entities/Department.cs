using EmployeeManagementAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<DepartmentEmployees>? DepartmentEmployees { get; set; }

        public static implicit operator string(Department v)
        {
            throw new NotImplementedException();
        }
    }
}
