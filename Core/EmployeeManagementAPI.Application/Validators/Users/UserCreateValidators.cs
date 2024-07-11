using EmployeeManagementAPI.Application.WiewModels.UsersWiewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Validators.Users
{
    public class UserCreateValidators :AbstractValidator<WM_Create_Users>
    {
        public UserCreateValidators()
        {
            RuleFor(u => u.Password).NotEmpty().NotNull().WithMessage("Password doesn`t be null!");
        }
    }
}
