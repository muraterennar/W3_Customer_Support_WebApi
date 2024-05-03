using Application.Features.Auth.Dtos;
using Core.Entities;
using Core.Security.JWT;

namespace Application.Features.Auth.LoginServices;

public interface ILoginService
{
    Task<CommonResponse<AccessToken>> LoginAsync(LoginDto loginDto);
}