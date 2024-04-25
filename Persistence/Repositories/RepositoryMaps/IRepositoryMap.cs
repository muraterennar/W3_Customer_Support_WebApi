using Core.Security.Entities;
using Domain.Entities;
using System.Data.SqlClient;

namespace Persistence.Repositories.RepositoryMaps;

public interface IRepositoryMap
{
    Employee MapEmployeeFromDataReader(SqlDataReader reader);

    OperationClaim MapOperationClaimFromDataReader(SqlDataReader reader);
}