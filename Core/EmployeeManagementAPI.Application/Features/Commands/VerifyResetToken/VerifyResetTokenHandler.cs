using EmployeeManagementAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.VerifyResetToken
{
    public class VerifyResetTokenHandler : IRequestHandler<VerifyResetTokenRequest, VerifyResetTokenResponse>
    {
        readonly IAuthService _authService;

        public VerifyResetTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<VerifyResetTokenResponse> Handle(VerifyResetTokenRequest request, CancellationToken cancellationToken)
        {
            bool state = await _authService.VerifyResetTokenAsync(request.ResetToken, request.UserId);
            return new()
            {
                State = state
            };
        }
    }
}
