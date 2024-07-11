using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.VerifyResetToken
{
    public class VerifyResetTokenRequest :IRequest<VerifyResetTokenResponse>
    {
        public string  ResetToken { get; set; }
        public int UserId { get; set; }
    }
}
