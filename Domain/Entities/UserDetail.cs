using Core.Entities;

namespace Domain.Entities;

public class UserDetail : Entity<int>
{
    public int CompanyId { get; set; }
    public int OperationClaimId { get; set; }
    public int UserOperationClaimId { get; set; }
    public int W3OperationClaimId { get; set; }
    public string UserNo { get; set; }
    public string UserEmail { get; set; }
    public string UserFirstname { get; set; }
    public string UserLastname { get; set; }
    public string Username { get; set; }
    public string OperationClaimName { get; set; }
    public string W3OperationClaimName { get; set; }
    public string PositionName { get; set; }
}
