using Application.Features.OperationClaimServices.Constants;
using Application.Features.OperationClaimServices.Dtos;
using Application.Features.OperationClaimServices.Rules;
using Core.Entities;
using Core.Security.Entities;
using Persistence.Repositories.OperationClaimRepositories;

namespace Application.Features.OperationClaimServices;

public class OperationClaimManager : IOperationClaimService
{
    string commonQuery = "SELECT [Id],[Name],[CreatedDate],[UpdatedDate],[DeletedDate]FROM [CatalystQa].[OPERATION_CLAIMS]";

    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly OperationClaimRules _operationClaimRules;

    public OperationClaimManager(IOperationClaimRepository operationClaimRepository, OperationClaimRules operationClaimRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _operationClaimRules = operationClaimRules;
    }

    public async Task<List<OperationClaim>> GetAllOperationClaimsAsync()
    {
        List<OperationClaim> result = await _operationClaimRepository.GetAll(commonQuery);
        return result;
    }

    public async Task<OperationClaim> GetByIdForOperationClaim(int id)
    {
        await _operationClaimRules.IsOperationClaimNotExist(id);

        string query = $"{commonQuery} WHERE [Id] = '{id}'";
        OperationClaim result = await _operationClaimRepository.GetByAny(query);
        return result;
    }

    public async Task<OperationClaim> GetByNameForOpearationClaim(string name)
    {
        await _operationClaimRules.IsOperationClaimNotExist(name);

        string query = $"{commonQuery} WHERE [Name] = '{name}'";
        OperationClaim result = await _operationClaimRepository.GetByAny(query);
        return result;
    }

    public async Task<CommonResponse<AddedOperationClaimDto>> Add(AddedOperationClaimDto operationClaimDto)
    {
        await _operationClaimRules.IsOperationClaimExist(operationClaimDto.Name);

        OperationClaim operationClaim = new OperationClaim
        {
            Name = operationClaimDto.Name,
            RECORD_DATE = DateTime.Now
        };

        string query = "INSERT INTO [CatalystQa].[OPERATION_CLAIMS] ([Name],[CreatedDate],[UpdatedDate]) VALUES (@Name, @CreatedDate, @UpdatedDate)";
        await _operationClaimRepository.Add(operationClaim, query);

        return new CommonResponse<AddedOperationClaimDto>
        {
            Data = operationClaimDto,
            Message = OperationClaimMessages.OperationClaimAdded,
            IsSuccess = true
        };
    }

    public async Task<CommonResponse<UpdatedOperationClaimDto>> Update(UpdatedOperationClaimDto updatedOperationClaimDto)
    {
        await _operationClaimRules.IsOperationClaimNotExist(updatedOperationClaimDto.Id);

        OperationClaim operationClaim = new OperationClaim
        {
            Id = updatedOperationClaimDto.Id,
            Name = updatedOperationClaimDto.Name,
            UPDATE_DATE = DateTime.Now
        };

        string query = "UPDATE [CatalystQa].[OPERATION_CLAIMS] SET [Name] = @Name, [UpdatedDate] = @UpdatedDate WHERE [Id] = @Id";

        await _operationClaimRepository.Update(operationClaim, query);

        return new CommonResponse<UpdatedOperationClaimDto>
        {
            Data = updatedOperationClaimDto,
            Message = OperationClaimMessages.OperationClaimUpdated,
            IsSuccess = true
        };
    }

    public async Task<CommonResponse<DeletedOperationClaimDto>> Delete(DeletedOperationClaimDto deletedOperationClaimDto)
    {
        await _operationClaimRules.IsOperationClaimNotExist(deletedOperationClaimDto.Id);

        OperationClaim operationClaim = new OperationClaim
        {
            Id = deletedOperationClaimDto.Id
        };

        string query = "DELETE FROM [CatalystQa].[OPERATION_CLAIMS] WHERE [Id] = @Id";

        await _operationClaimRepository.Delete(operationClaim, query);

        return new CommonResponse<DeletedOperationClaimDto>
        {
            Data = deletedOperationClaimDto,
            Message = OperationClaimMessages.OperationClaimDeleted,
            IsSuccess = true
        };
    }
}