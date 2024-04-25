using Core.Entities;
using Domain.Dtos;

namespace Application.Features.Auth.LoginServices;

public interface ILoginService
{
    Task<CommonResponse<LoginResponse>> LoginAsync(LoginDto loginDto);
}