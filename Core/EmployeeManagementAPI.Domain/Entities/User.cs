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
    public class User : IdentityUser<int> //BaseEntity
    {
        override public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        override public string? Email { get; set; }
        public string Password { get; set; }
        public byte[]? HashedPassword { get; set; }
        public byte[]? SaltedPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        //public ICollection<UserPermission> UserPermissions { get; set; }

    }
}
