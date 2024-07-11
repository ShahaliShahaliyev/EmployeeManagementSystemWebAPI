﻿using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence.Repositories
{
    public class PositionWriteRepository : WriteRepository<Position>, IPositionWriteRepository
    {
        public PositionWriteRepository(EmployeeManagementAPIDbContext context) : base(context)
        {
        }
    }
}