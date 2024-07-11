using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Exceptions
{
    public class CreateUserFailException : Exception
    {
        public CreateUserFailException()
        {
        }

        public CreateUserFailException(string? message) : base(message)
        {
        }

        public CreateUserFailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
