using Application.Features.UserOperationClaimServices.Rules;
using Core.Security.Entities;
using Domain.Dtos;
using Persistence.Repositories.UserOperationClaimRepositories;

namespace Application.Features.UserOperationClaimServices;

public class UserOperationClaimManager : IUserOperationClaimService
{
    string commonQuery = "SELECT [Id],[UserId],[OperationClaimId],[CreatedDate],[UpdatedDate],[DeletedDate] FROM [CatalystQa].[USER_OPERATION_CLAIMS]";

    private readonly IUserOperationClaimReposiyory _userOperationClaimRepository;
    private readonly UserOperationClaimRules _userOperationClaimRules;

    public UserOperationClaimManager(IUserOperationClaimReposiyory userOperationClaimRepository, UserOperationClaimRules userOperationClaimRules)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _userOperationClaimRules = userOperationClaimRules;
    }

    public async Task<List<UserOperationClaimDto>> GetAll()
    {
        List<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetAll(commonQuery);

        List<UserOperationClaimDto> result = userOperationClaims.Select(userOperationClaim => new UserOperationClaimDto
        {
            Id = userOperationClaim.Id,
            UserId = userOperationClaim.UserId,
            OperationClaimId = userOperationClaim.OperationClaimId
        }).ToList();

        return result;
    }

    public async Task<UserOperationClaimDto> GetByIdForUserOperationClaim(int id)
    {
        await _userOperationClaimRules.IsUserOperationClaimNotExist(id);

        string query = $"{commonQuery} WHERE [Id] = {id}";
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetByAny(query);

        UserOperationClaimDto result = new UserOperationClaimDto
        {
            Id = userOperationClaim.Id,
            UserId = userOperationClaim.UserId,
            OperationClaimId = userOperationClaim.OperationClaimId
        };

        return result;
    }

    public async Task<UserOperationClaimDto> GetByUserIdForUserOperationClaim(int userId)
    {
        await _userOperationClaimRules.IsUserIdExist(userId);

        string query = $"{commonQuery} WHERE [UserId] = {userId}";
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetByAny(query);

        UserOperationClaimDto result = new UserOperationClaimDto
        {
            Id = userOperationClaim.Id,
            UserId = userOperationClaim.UserId,
            OperationClaimId = userOperationClaim.OperationClaimId
        };

        return result;
    }

    public async Task<UserOperationClaimDto> GetByOperationClaimIdForUserOperationClaim(int operationId)
    {
        await _userOperationClaimRules.IsUserOperationClaimExist(operationId);

        string query = $"{commonQuery} WHERE [OperationClaimId] = {operationId}";
        UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetByAny(query);

        UserOperationClaimDto result = new UserOperationClaimDto
        {
            Id = userOperationClaim.Id,
            UserId = userOperationClaim.UserId,
            OperationClaimId = userOperationClaim.OperationClaimId
        };

        return result;
    }

    public async Task<UserOperationClaimDto> Add(UserOperationClaimDto userOperationClaimDto)
    {
        await _userOperationClaimRules.IsUserOperationClaimExist(userOperationClaimDto.UserId, userOperationClaimDto.OperationClaimId);

        UserOperationClaim userOperationClaimEntity = new()
        {
            UserId = userOperationClaimDto.UserId,
            OperationClaimId = userOperationClaimDto.OperationClaimId,
            RECORD_DATE = DateTime.UtcNow
        };

        string query = $"INSERT INTO [CatalystQa].[USER_OPERATION_CLAIMS]([UserId], [OperationClaimId], [CreatedDate], [UpdatedDate]) VALUES (@UserId, @OperationClaimId, @CreatedDate, @UpdatedDate)";
        UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.Add(userOperationClaimEntity, query);

        userOperationClaimDto = new UserOperationClaimDto
        {
            Id = createdUserOperationClaim.Id,
            UserId = createdUserOperationClaim.UserId,
            OperationClaimId = createdUserOperationClaim.OperationClaimId,
        };

        return userOperationClaimDto;
    }

    public async Task<UserOperationClaimDto> Update(UserOperationClaimDto userOperationClaimDto)
    {
        await _userOperationClaimRules.IsUserOperationClaimNotExist(userOperationClaimDto.UserId, userOperationClaimDto.OperationClaimId);

        UserOperationClaim userOperationClaim = new()
        {
            Id = userOperationClaimDto.Id,
            UserId = userOperationClaimDto.UserId,
            OperationClaimId = userOperationClaimDto.OperationClaimId,
            UPDATE_DATE = DateTime.UtcNow
        };

        string query = $"UPDATE [CatalystQa].[USER_OPERATION_CLAIMS] SET [UserId] = @UserId, @OperationClaimId, [UpdatedDate] = GETDATE() WHERE [Id] = @Id";

        UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.Update(userOperationClaim, query);

        userOperationClaimDto = new UserOperationClaimDto
        {
            Id = updatedUserOperationClaim.Id,
            UserId = updatedUserOperationClaim.UserId,
            OperationClaimId = updatedUserOperationClaim.OperationClaimId,
        };

        return userOperationClaimDto;

    }

    public async Task<UserOperationClaimDto> Delete(UserOperationClaimDto userOperationClaimDto)
    {
        await _userOperationClaimRules.IsUserOperationClaimNotExist(userOperationClaimDto.UserId, userOperationClaimDto.OperationClaimId);

        UserOperationClaim userOperationClaim = new()
        {
            Id = userOperationClaimDto.Id,
            OperationClaimId = userOperationClaimDto.OperationClaimId,
            UserId = userOperationClaimDto.UserId
        };

        string query = $"DELETE FROM [CatalystQa].[USER_OPERATION_CLAIMS] WHERE [Id] = @Id";

        UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.Delete(userOperationClaim, query);

        userOperationClaimDto = new UserOperationClaimDto
        {
            Id = deletedUserOperationClaim.Id,
            UserId = deletedUserOperationClaim.UserId,
            OperationClaimId = deletedUserOperationClaim.OperationClaimId
        };

        return userOperationClaimDto;
    }
}