using EmployeeManagementAPI.API.Extensions;
using EmployeeManagementAPI.API.Filters;
using EmployeeManagementAPI.Application;
using EmployeeManagementAPI.Application.Repositories;
using EmployeeManagementAPI.Application.Validators.Positions;
using EmployeeManagementAPI.Domain.Entities;
using EmployeeManagementAPI.Infrastructure.Filters;
using EmployeeManagementAPI.Persistence;
using EmployeeManagementAPI.Persistence.Contexts;
using EmployeeManagementAPI.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeManagementAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


//builder.Services.AddTransient<EmployeeManagementAPIDbContext>();
builder.Services.AddIdentity<User, Permission>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<EmployeeManagementAPIDbContext>()
.AddDefaultTokenProviders();
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();
builder.Services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
builder.Services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
builder.Services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
builder.Services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
builder.Services.AddScoped<IPositionReadRepository, PositionReadRepository>();
builder.Services.AddScoped<IPositionWriteRepository, PositionWriteRepository>();
//builder.Services.AddScoped<IUserReadRepository, UserReadRepository>();
//builder.Services.AddScoped<IUserWriteRepository, UserWriteRepository>();


//Logger log = new LoggerConfiguration().WriteTo.File("logs/log.txt")
//    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
//    , "logs",autoCreateSqlTable:true,
//    columnOptions:new Dictionary<string, ColumnBase>
//    {
//        {"message", }
//    })
//    .CreateLogger();

//builder.Host.UseSerilog(log);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilters>();
    options.Filters.Add<RolePermissionFilter>();
})
  .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<PositionCreateValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
            NameClaimType = ClaimTypes.Name
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();
app.UseCors();

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
