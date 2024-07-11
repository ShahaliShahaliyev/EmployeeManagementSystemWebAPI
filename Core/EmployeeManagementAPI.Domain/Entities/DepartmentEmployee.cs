using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Domain.Entities
{
    public class DepartmentEmployees
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }
    }
}
