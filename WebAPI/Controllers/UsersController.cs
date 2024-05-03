using Application.Features.UserService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _userService.GetAllUsersAsync();
        return Ok(response);
    }

    [HttpGet("GetAllUserDetail")]
    public async Task<IActionResult> GetAllUserDetailAsync()
    {
        var result = await _userService.GetAllUserDetailAsync();
        return Ok(result);
    }

    [HttpGet("GetByUserIdForDetailList/{userId}")]
    public async Task<IActionResult> GetUserIdForUserDetailListAsync([FromRoute] int userId)
    {
        var response = await _userService.GetUserIdForUserDetailListAsync(userId);
        return Ok(response);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var response = await _userService.GetByIdForUserAsync(id);
        return Ok(response);
    }

    [HttpGet("GetByFirstName")]
    public async Task<IActionResult> GetByFirstNameAsync([FromQuery] string firstName)
    {
        var response = await _userService.GetByFirstNameForUserAsync(firstName);
        return Ok(response);
    }

    [HttpGet("GetByLastName")]
    public async Task<IActionResult> GetByLastName([FromQuery] string lastName)
    {
        var response = await _userService.GetByLastNameForUserAsync(lastName);
        return Ok(response);
    }

    [HttpGet("GetByEmail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var response = await _userService.GetByEmailForUserAsync(email);
        return Ok(response);
    }

    [HttpGet("GetByPhoneNumber")]
    public async Task<IActionResult> GetByPhoneNumber([FromQuery] string phoneNumber)
    {
        var response = await _userService.GetByPhoneNumberForUserAsync(phoneNumber);
        return Ok(response);
    }
}
