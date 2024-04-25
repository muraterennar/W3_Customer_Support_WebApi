using Core.Security.Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    public AccessToken CreateToken(SecurityUser user, List<OperationClaim> operationClaims);
}
