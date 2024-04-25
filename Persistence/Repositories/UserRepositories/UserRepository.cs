using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.RepositoryMaps;

namespace Persistence.Repositories.UserRepositories;

public class UserRepository : BaseRepository<Employee>, IUserRepository
{
    public UserRepository(IConfiguration conguration, IRepositoryMap mapModel) : base(conguration, mapModel)
    {
    }
}