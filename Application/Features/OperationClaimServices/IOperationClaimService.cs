using Application.Features.OperationClaimServices.Dtos;
using Core.Entities;
using Core.Security.Entities;

namespace Application.Features.OperationClaimServices;

public interface IOperationClaimService
{
    Task<List<OperationClaim>> GetAllOperationClaimsAsync();
    Task<OperationClaim> GetByIdForOperationClaim(int id);
    Task<OperationClaim> GetByNameForOpearationClaim(string name);

    Task<CommonResponse<AddedOperationClaimDto>> Add(AddedOperationClaimDto operationClaim);
    Task<CommonResponse<UpdatedOperationClaimDto>> Update(UpdatedOperationClaimDto operationClaim);
    Task<CommonResponse<DeletedOperationClaimDto>> Delete(DeletedOperationClaimDto operationClaim);
}
