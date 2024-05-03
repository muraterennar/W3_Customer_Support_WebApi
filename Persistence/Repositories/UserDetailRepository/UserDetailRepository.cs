using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.RepositoryMaps;

namespace Persistence.Repositories.UserDetailRepository;

public class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
{
    public UserDetailRepository(IConfiguration conguration, IRepositoryMap mapModel) : base(conguration, mapModel)
    {
    }
}
