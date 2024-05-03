using Application.Features.UserOperationClaimServices.Dtos;

namespace Application.Features.UserOperationClaimServices;

public interface IUserOperationClaimService
{
    public Task<List<UserOperationClaimDto>> GetAll();
    public Task<List<UserOperationClaimDto>> GetByUserIdForUserOperationClaimList(int userId);
    public Task<UserOperationClaimDto> GetByIdForUserOperationClaim(int id);
    public Task<UserOperationClaimDto> GetByUserIdForUserOperationClaim(int userId);
    public Task<UserOperationClaimDto> GetByOperationClaimIdForUserOperationClaim(int operationId);

    public Task<AddedUserOperationClaimDto> Add(AddedUserOperationClaimDto userOperationClaimDto);
    public Task<UpdatedUserOperationClaimDto> Update(UpdatedUserOperationClaimDto userOperationClaimDto);
    public Task<DeletedUserOperationClaimDto> Delete(DeletedUserOperationClaimDto userOperationClaimDto);
}