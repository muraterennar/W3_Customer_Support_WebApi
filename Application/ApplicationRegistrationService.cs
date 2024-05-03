using Application.Features.Auth.LoginServices;
using Application.Features.Auth.TokenServices;
using Application.Features.OperationClaimServices;
using Application.Features.UserOperationClaimServices;
using Application.Features.UserService;
using Core.Rules;
using Core.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationRegistrationService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // All Rules Inject
        services.AddSubClassessOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        // OperationClaimRules aracılığıyla OperationClaimManager'a bağımlılığı kaldırarak döngüyü çözebilirsiniz.
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<ILoginService, LoginManager>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenManager>();
        services.AddScoped<ITokenHelper, JWTHelper>();

        return services;
    }

    public static IServiceCollection AddSubClassessOfType(this IServiceCollection services, Assembly assembly,
    Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

        foreach(var typ in types)
            if(addWithLifeCycle == null)
                services.AddScoped(typ);
            else
                addWithLifeCycle(services, typ);
        return services;
    }
}
