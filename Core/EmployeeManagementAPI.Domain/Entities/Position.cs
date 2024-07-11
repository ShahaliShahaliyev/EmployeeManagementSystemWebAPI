using EmployeeManagementAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<EmployeePosition> EmployeePositions { get; set; }

    }
}
