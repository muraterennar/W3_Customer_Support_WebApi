using Core.Exceptions;
using Core.Rules;
using Core.Security.Entities;
using Persistence.Repositories.UserOperationClaimRepositories;

namespace Application.Features.UserOperationClaimServices.Rules;

public class UserOperationClaimRules : BaseBusinessRules
{
    string commonQuery = "SELECT [Id],[UserId],[OperationClaimId],[CreatedDate],[UpdatedDate] FROM [CatalystQa].[USER_OPERATION_CLAIMS]";

    private readonly IUserOperationClaimReposiyory _userOperationClaimReposiyory;

    public UserOperationClaimRules(IUserOperationClaimReposiyory userOperationClaimReposiyory)
    {
        _userOperationClaimReposiyory = userOperationClaimReposiyory;
    }

    public async Task IsUserOperationClaimExist(int userId, int operationClaimId)
    {
        string query = $"{commonQuery} WHERE [UserId] = '{userId}' AND [OperationClaimId] = '{operationClaimId}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim != null)
        {
            throw new BusinessException("User operation claim already exists.");
        }
    }

    public async Task IsUserOperationClaimNotExist(int id)
    {
        string query = $"{commonQuery} WHERE [Id] = '{id}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim == null)
        {
            throw new BusinessException("User operation claim not found.");
        }
    }

    public async Task IsUserOperationClaimNotExist(int userId, int operationClaimId)
    {
        string query = $"{commonQuery} WHERE [UserId] = '{userId}' AND [OperationClaimId] = '{operationClaimId}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim == null)
        {
            throw new BusinessException("User operation claim not found.");
        }
    }

    public async Task IsUserOperationClaimExist(int id)
    {
        string query = $"{commonQuery} WHERE [Id] = '{id}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim == null)
        {
            throw new BusinessException("User operation claim not found.");
        }
    }

    public async Task IsUserIdExist(int userId)
    {
        string query = $"{commonQuery} WHERE [UserId] = '{userId}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim == null)
        {
            throw new BusinessException("User id not found.");
        }
    }

    public async Task IsOperationClaimIdExist(int operationClaimId)
    {
        string query = $"{commonQuery} WHERE [OperationClaimId] = '{operationClaimId}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim == null)
        {
            throw new BusinessException("Operation claim id not found.");
        }
    }

    public async Task IsUserIdNotExist(int userId)
    {
        string query = $"{commonQuery} WHERE [UserId] = '{userId}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim != null)
        {
            throw new BusinessException("User id already exists.");
        }
    }

    public async Task IsOperationClaimIdNotExist(int operationClaimId)
    {
        string query = $"{commonQuery} WHERE [OperationClaimId] = '{operationClaimId}'";
        UserOperationClaim userOperationClaim = await _userOperationClaimReposiyory.GetByAny(query);

        if(userOperationClaim != null)
        {
            throw new BusinessException("Operation claim id already exists.");
        }
    }
}