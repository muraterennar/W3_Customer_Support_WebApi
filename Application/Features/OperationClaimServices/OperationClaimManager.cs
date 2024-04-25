using Application.Features.OperationClaimServices.Dtos;
using Core.Entities;
using Core.Security.Entities;
using Persistence.Repositories.OperationClaimRepositories;

namespace Application.Features.OperationClaimServices;

public class OperationClaimManager : IOperationClaimService
{
    string commonQuery = "SELECT [Id],[Name],[CreatedDate],[UpdatedDate],[DeletedDate]FROM [CatalystQa].[OPERATION_CLAIMS]";

    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task<List<OperationClaim>> GetAllOperationClaimsAsync()
    {
        List<OperationClaim> result = await _operationClaimRepository.GetAll(commonQuery);
        return result;
    }

    public async Task<OperationClaim> GetByIdForOperationClaim(int id)
    {
        string query = $"{commonQuery} WHERE [Id] = '{id}'";
        OperationClaim result = await _operationClaimRepository.GetByAny(query);
        return result;
    }

    public async Task<OperationClaim> GetByNameForOpearationClaim(string name)
    {
        string query = $"{commonQuery} WHERE [Name] = '{name}'";
        OperationClaim result = await _operationClaimRepository.GetByAny(query);
        return result;
    }

    public async Task<CommonResponse<AddedOperationClaimDto>> Add(AddedOperationClaimDto operationClaimDto)
    {
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
            Message = "Operation Claim added successfully",
            IsSuccess = true
        };
    }

    public async Task<CommonResponse<OperationClaim>> Delete(OperationClaim operationClaim)
    {
        throw new NotImplementedException();
    }

    public async Task<CommonResponse<OperationClaim>> Update(OperationClaim operationClaim)
    {
        throw new NotImplementedException();
    }
}