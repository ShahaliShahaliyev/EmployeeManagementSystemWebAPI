using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserCommandRequest :IRequest<LoginUserCommandResponse>
    {
        public string UsernameorEmail { get; set; }
        public string Password { get; set; }
    }
}
