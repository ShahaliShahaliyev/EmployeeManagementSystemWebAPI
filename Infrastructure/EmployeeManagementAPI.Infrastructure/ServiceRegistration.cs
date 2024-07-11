using EmployeeManagementAPI.Application.Abstractions.Services;
using EmployeeManagementAPI.Application.Abstractions.Services.Configurations;
using EmployeeManagementAPI.Application.Abstractions.Token;
using EmployeeManagementAPI.Infrastructure.Services;
using EmployeeManagementAPI.Infrastructure.Services.Configurations;
using EmployeeManagementAPI.Infrastructure.Services.TokenService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection collection)
        {
            collection.AddScoped<ITokenHandler,TokenHandler>();
            collection.AddScoped<IMailService,MailService>();
            collection.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
