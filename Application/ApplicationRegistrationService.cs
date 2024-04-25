using Application.Features.Auth.LoginServices;
using Application.Features.EmployeeServices;
using Application.Features.OperationClaimServices;
using Application.Features.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationRegistrationService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}