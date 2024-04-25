using Core.Entities;

namespace Core.Security.Entities;

public class UserOperationClaim : Entity<int>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}