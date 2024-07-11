using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Exceptions
{
    public class NotFoundUsernameException : Exception
    {
        public NotFoundUsernameException() : base("Username or Password incorrect... ") 
        {
        }

        public NotFoundUsernameException(string? message) : base(message)
        {
        }

        public NotFoundUsernameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundUsernameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
