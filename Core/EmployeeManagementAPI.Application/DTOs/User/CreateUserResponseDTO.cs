using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.DTOs.User
{
    public class CreateUserResponseDTO
    {
        public bool Succedded { get; set; }
        public string Message { get; set; }
    }
}
