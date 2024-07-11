﻿using EmployeeManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application.Repositories
{
    public interface IDepartmentEmployeeReadRepository : IReadContainedRepository<DepartmentEmployees>
    {
    }
}