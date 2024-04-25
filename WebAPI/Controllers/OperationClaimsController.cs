using Application.Features.OperationClaimServices;
using Application.Features.OperationClaimServices.Dtos;
using Core.Entities;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _operationClaimService.GetAllOperationClaimsAsync();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _operationClaimService.GetByIdForOperationClaim(id);
            return Ok(response);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var response = await _operationClaimService.GetByNameForOpearationClaim(name);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddedOperationClaimDto operationClaim)
        {
            CommonResponse<AddedOperationClaimDto> response = await _operationClaimService.Add(operationClaim);
            return Ok(response);
        }
    }
}
