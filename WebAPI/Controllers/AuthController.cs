using Application.Features.Auth.LoginServices;
using Core.Entities;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILoginService _loginService;

    public AuthController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        CommonResponse<LoginResponse> response = await _loginService.LoginAsync(loginDto);
        return Ok(response);
    }
}
