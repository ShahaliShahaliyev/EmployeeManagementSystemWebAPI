using MediatR;

namespace EmployeeManagementAPI.Application.Features.Commands.Users.UpdatePassword
{
    public class UpdatePasswordCommandReuqest :IRequest<UpdatePasswordCommandResponse>
    {
        public int UserId { get; set; }
        public string  ResetToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}