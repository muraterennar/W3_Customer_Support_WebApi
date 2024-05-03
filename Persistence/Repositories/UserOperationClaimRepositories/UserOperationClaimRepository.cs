using Core.Security.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.RepositoryMaps;

namespace Persistence.Repositories.UserOperationClaimRepositories;

public class UserOperationClaimRepository : BaseRepository<UserOperationClaim>, IUserOperationClaimReposiyory
{
    public UserOperationClaimRepository(IConfiguration conguration, IRepositoryMap mapModel) : base(conguration, mapModel)
    {
    }
}
