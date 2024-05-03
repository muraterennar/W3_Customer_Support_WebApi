using Core.Security.JWT;
using Domain.Entities;

namespace Application.Features.Auth.TokenServices;

public interface ITokenService
{
    Task<AccessToken> CreateAccessToken(Employee user);
}
