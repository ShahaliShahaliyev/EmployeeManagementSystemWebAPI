using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.DTOs.Employees
{
    public class CreateEmployee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthOfDate { get; set; }
        public int MyProperty { get; set; }
    }
}
