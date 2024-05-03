using Application.Features.OperationClaimServices;
using Application.Features.UserOperationClaimServices;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Auth.TokenServices;

public class TokenManager : ITokenService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly TokenOptions _tokenOptions;
    private readonly IOperationClaimService _operationClaimService;
    private readonly IUserOperationClaimService _userOperationClaimService;

    public TokenManager(ITokenHelper tokenHelper, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService, IConfiguration configuration)
    {
        _tokenHelper = tokenHelper;
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>() ?? new();
        _operationClaimService = operationClaimService;
        _userOperationClaimService = userOperationClaimService;
    }

    public async Task<AccessToken> CreateAccessToken(Employee user)
    {
        List<OperationClaim> operationClaims = await GetClaims(user);

        SecurityUser securityUser = new SecurityUser
        {
            EmployeeId = user.Id,
            Email = user.EMPLOYEE_EMAIL,
            FirstName = user.EMPLOYEE_NAME,
            LastName = user.EMPLOYEE_SURNAME,
            Username = user.EMPLOYEE_USERNAME,
            EmployeeCode = user.EMPLOYEE_NO
        };

        AccessToken token = _tokenHelper.CreateToken(securityUser, operationClaims);

        return token;
    }

    private async Task<List<OperationClaim>> GetClaims(Employee user)
    {
        //List<UserOperationClaim> userOperationClaims = await _userOperationClaimService.GetByUserIdForUserOperationClaim(user.Id);
        var userOperationClaims = await _userOperationClaimService.GetByUserIdForUserOperationClaimList(user.Id);

        List<OperationClaim> operationClaims = new();

        foreach(var userOperationClaim in userOperationClaims)
        {
            OperationClaim operationClaim = await _operationClaimService.GetByIdForOperationClaim(userOperationClaim.OperationClaimId);
            operationClaims.Add(operationClaim);
        }

        return operationClaims;
    }

}