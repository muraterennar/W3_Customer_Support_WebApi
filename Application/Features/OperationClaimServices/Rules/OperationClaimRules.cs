using Application.Features.OperationClaimServices.Constants;
using Core.Exceptions;
using Core.Rules;
using Core.Security.Entities;
using Persistence.Repositories.OperationClaimRepositories;

namespace Application.Features.OperationClaimServices.Rules;

public class OperationClaimRules : BaseBusinessRules
{
    string commonQuery = "SELECT [Id],[Name],[CreatedDate],[UpdatedDate] FROM [CatalystQa].[OPERATION_CLAIMS]";

    private readonly IOperationClaimRepository _operationClaimRepository;


    public OperationClaimRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task IsOperationClaimExist(int id)
    {
        string query = $"{commonQuery} WHERE [Id] = '{id}'";
        OperationClaim operationClaim = await _operationClaimRepository.GetByAny(query);
        if(operationClaim != null)
        {
            throw new BusinessException(OperationClaimMessages.OperationClaimAlreadyExist);
        }
    }

    public async Task IsOperationClaimNotExist(int id)
    {
        string query = $"{commonQuery} WHERE [Id] = '{id}'";
        OperationClaim operationClaim = await _operationClaimRepository.GetByAny(query);
        if(operationClaim == null)
        {
            throw new BusinessException(OperationClaimMessages.OperationClaimNotFound);
        }
    }

    public async Task IsOperationClaimExist(string name)
    {
        string query = $"{commonQuery} WHERE [Name] = '{name}'";
        OperationClaim operationClaim = await _operationClaimRepository.GetByAny(query);
        if(operationClaim != null)
        {
            throw new BusinessException(OperationClaimMessages.OperationClaimAlreadyExist);
        }
    }

    public async Task IsOperationClaimNotExist(string name)
    {
        string query = $"{commonQuery} WHERE [Name] = '{name}'";
        OperationClaim operationClaim = await _operationClaimRepository.GetByAny(query);
        if(operationClaim == null)
        {
            throw new BusinessException(OperationClaimMessages.OperationClaimNotFound);
        }
    }
}