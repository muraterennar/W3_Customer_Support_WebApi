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
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _operationClaimService.GetByIdForOperationClaim(id);
            return Ok(response);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            var response = await _operationClaimService.GetByNameForOpearationClaim(name);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddedOperationClaimDto operationClaim)
        {
            CommonResponse<AddedOperationClaimDto> response = await _operationClaimService.Add(operationClaim);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatedOperationClaimDto operationClaim)
        {
            CommonResponse<UpdatedOperationClaimDto> response = await _operationClaimService.Update(operationClaim);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletedOperationClaimDto operationClaim = new DeletedOperationClaimDto
            {
                Id = id
            };

            CommonResponse<DeletedOperationClaimDto> response = await _operationClaimService.Delete(operationClaim);
            return Ok(response);
        }
    }
}
