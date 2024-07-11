using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Abstractions.Token;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Persistence.Repositories;
using EmployeeManagementAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Persistence
{
    public static class ServiceRegstration
    {
        public static void AddPersistenceServices(this IServiceCollection collection)
        {
            collection.AddHttpClient();
            collection.AddScoped<IUserService,UserService>();
            collection.AddScoped<IAuthService,AuthService>();
            collection.AddScoped<IRoleService,RoleService>();
            collection.AddScoped<IDepartmentService,DepartmentService>();
            collection.AddScoped<IMenuWriteRepository,MenuWriteRepository>();
            collection.AddScoped<IMenuReadRepository,MenuReadRepository>();
            collection.AddScoped<IEndpointReadRepository,EndpointReadRepository>();
            collection.AddScoped<IEndpointWriteRepository,EndpointWriteRepository>();
            collection.AddScoped<IAuthorizationEndpointService,AuthorizationEndpointService>();
            collection.AddScoped<IDepartmentEmployeesService,DepartmentEmployeesService>();
            collection.AddScoped<IDepartmentEmployeeWriteRepository,DepartmentEmployeeWriteRepository>();
        }
    }
}
