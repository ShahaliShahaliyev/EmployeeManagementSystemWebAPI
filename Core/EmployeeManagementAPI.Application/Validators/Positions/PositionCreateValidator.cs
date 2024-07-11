using EmployeeManagementAPI.Application.WiewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Validators.Positions
{
    public class PositionCreateValidator : AbstractValidator<WM_Create_Position>
    {
        public PositionCreateValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                           .WithMessage("Name don`t declare null");
        }
    }
}
