using Core.Security.Entities;
using Domain.Dtos;

namespace Application.Features.UserOperationClaimServices;

public interface IUserOperationClaimService
{
    public Task<List<UserOperationClaimDto>> GetAll();
    public Task<UserOperationClaimDto> GetByIdForUserOperationClaim(int id);
    public Task<UserOperationClaimDto> GetByUserIdForUserOperationClaim(int userId);
    public Task<UserOperationClaimDto> GetByOperationClaimIdForUserOperationClaim(int operationId);

    public Task<UserOperationClaimDto> Add(UserOperationClaimDto userOperationClaimDto);
    public Task<UserOperationClaimDto> Update(UserOperationClaimDto userOperationClaimDto);
    public Task<UserOperationClaimDto> Delete(UserOperationClaimDto userOperationClaimDto);
}