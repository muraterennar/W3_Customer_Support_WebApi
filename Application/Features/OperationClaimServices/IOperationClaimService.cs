using Application.Features.OperationClaimServices.Dtos;
using Core.Entities;
using Core.Security.Entities;
using Domain.Dtos;

namespace Application.Features.OperationClaimServices;

public interface IOperationClaimService
{
    Task<List<OperationClaim>> GetAllOperationClaimsAsync();
    Task<OperationClaim> GetByIdForOperationClaim(int id);
    Task<OperationClaim> GetByNameForOpearationClaim(string name);

    Task<CommonResponse<AddedOperationClaimDto>> Add(AddedOperationClaimDto operationClaim);
    Task<CommonResponse<OperationClaim>> Update(OperationClaim operationClaim);
    Task<CommonResponse<OperationClaim>> Delete(OperationClaim operationClaim);
}
