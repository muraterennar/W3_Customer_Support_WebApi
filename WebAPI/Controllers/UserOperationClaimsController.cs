using Application.Features.UserOperationClaimServices;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : ControllerBase
{
    private readonly IUserOperationClaimService _userOperationClaimService;

    public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
    {
        _userOperationClaimService = userOperationClaimService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userOperationClaimService.GetAll();
        return Ok(result);
    }

    [HttpGet("GetByIdForUserOperationClaim")]
    public async Task<IActionResult> GetByIdForUserOperationClaim(int id)
    {
        var result = await _userOperationClaimService.GetByIdForUserOperationClaim(id);
        return Ok(result);
    }

    [HttpGet("GetByUserIdForUserOperationClaim")]
    public async Task<IActionResult> GetByUserIdForUserOperationClaim(int userId)
    {
        var result = await _userOperationClaimService.GetByUserIdForUserOperationClaim(userId);
        return Ok(result);
    }

    [HttpGet("GetByOperationClaimIdForUserOperationClaim")]
    public async Task<IActionResult> GetByOperationClaimIdForUserOperationClaim(int operationId)
    {
        var result = await _userOperationClaimService.GetByOperationClaimIdForUserOperationClaim(operationId);
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(UserOperationClaimDto userOperationClaimDto)
    {
        var result = await _userOperationClaimService.Add(userOperationClaimDto);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UserOperationClaimDto userOperationClaimDto)
    {
        var result = await _userOperationClaimService.Update(userOperationClaimDto);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(UserOperationClaimDto userOperationClaimDto)
    {
        var result = await _userOperationClaimService.Delete(userOperationClaimDto);
        return Ok(result);
    }
}
