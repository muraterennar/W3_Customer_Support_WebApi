using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.EmployeeRepositories;
using Persistence.Repositories.OperationClaimRepositories;
using Persistence.Repositories.RepositoryMaps;
using Persistence.Repositories.UserRepositories;

namespace Persistence;

public static class PersistenceRegistrationService
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection service)
    {
        service.AddScoped<IRepositoryMap, RepositoryMap>();
        service.AddScoped<IEmployeeRepository, EmployeeRepository>();
        service.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        service.AddScoped<IUserRepository, UserRepository>();
        return service;
    }
}