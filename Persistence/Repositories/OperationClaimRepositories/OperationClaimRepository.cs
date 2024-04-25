using Core.Security.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.RepositoryMaps;

namespace Persistence.Repositories.OperationClaimRepositories;

public class OperationClaimRepository : BaseRepository<OperationClaim>, IOperationClaimRepository
{
    public OperationClaimRepository(IConfiguration conguration, IRepositoryMap mapModel) : base(conguration, mapModel)
    {
    }
}
