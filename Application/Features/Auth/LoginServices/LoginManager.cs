using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Features.Auth.TokenServices;
using Application.Features.UserService;
using Core.Entities;
using Core.Security.JWT;
using Domain.Entities;

namespace Application.Features.Auth.LoginServices;

public class LoginManager : ILoginService
{
    private readonly IUserService _userService;
    private readonly AuthRules _authRules;
    private readonly ITokenService _tokenService;

    public LoginManager(IUserService userService, AuthRules authRules, ITokenService tokenService)
    {
        _userService = userService;
        _authRules = authRules;
        _tokenService = tokenService;
    }

    public async Task<CommonResponse<AccessToken>> LoginAsync(LoginDto loginDto)
    {
        await _authRules.IsUserNotExist(loginDto.Username);
        await _authRules.IsPasswordCorrect(loginDto.Username, loginDto.Password);


        Employee getEmployee = await _userService.GetByUsernameForUserAsync(loginDto.Username);

        AccessToken accessToken = await _tokenService.CreateAccessToken(getEmployee);

        return new CommonResponse<AccessToken>
        {
            Data = accessToken,
            Message = "Login Success",
            IsSuccess = true
        };
    }
}