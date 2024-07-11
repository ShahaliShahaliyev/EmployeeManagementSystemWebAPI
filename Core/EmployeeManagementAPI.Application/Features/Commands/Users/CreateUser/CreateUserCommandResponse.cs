using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool  Succedded { get; set; }
        public string Message { get; set; }
    }
}
