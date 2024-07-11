using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandReuqest, UpdatePasswordCommandResponse>
    {
        readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async  Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandReuqest request, CancellationToken cancellationToken)
        {
            if (request.Password == request.PasswordConfirm)
                throw new PasswordChangeFailedException();

           await _userService.UpdatePasswordAsync(request.UserId,
                request.ResetToken,request.Password);

            return new();
        }
    }
}
