using EmployeeManagementAPI.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Domain.Entities
{
    public class Permission : IdentityRole<int>
    {
       override public int Id { get; set; }
        public ICollection<Endpoint> Endpoints { get; set; }
        //public string Name { get; set; }
        //public ICollection<UserPermission> UserPermissions { get; set; }

    }
}
