using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Domain.Entities
{
    public class EmployeePosition
    {
        public int PositionId { get; set; }
        public int EmployeeId { get; set; }

        public Position Position { get; set; }
        public Employee Employee { get; set; }
    }
}
