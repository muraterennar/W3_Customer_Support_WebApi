using Core.Security.JWT;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.OperationClaimRepositories;
using Persistence.Repositories.UserRepositories;

namespace Application.Features.Auth.TokenServices;

public class TokenManager : ITokenService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly TokenOptions _tokenOptions;
    private readonly IUserRepository _userRepository;
    private readonly IOperationClaimRepository _operationClaimRepository;

    public TokenManager(ITokenHelper tokenHelper, IUserRepository userRepository, IConfiguration configuration, IOperationClaimRepository operationClaimRepository)
    {
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>() ?? new();
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task<AccessToken> CreateAccessToken(Employee user)
    {
        return Task.FromResult(new AccessToken()).Result;
    }
}