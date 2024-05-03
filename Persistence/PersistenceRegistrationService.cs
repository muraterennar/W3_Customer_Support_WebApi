using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.OperationClaimRepositories;
using Persistence.Repositories.RepositoryMaps;
using Persistence.Repositories.UserDetailRepository;
using Persistence.Repositories.UserOperationClaimRepositories;
using Persistence.Repositories.UserRepositories;

namespace Persistence;

public static class PersistenceRegistrationService
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection service)
    {
        service.AddScoped<IRepositoryMap, RepositoryMap>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IUserDetailRepository, UserDetailRepository>();
        service.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        service.AddScoped<IUserOperationClaimReposiyory, UserOperationClaimRepository>();
        return service;
    }
}