using App.Api.Controllers.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.Tools
{
  [Route("tools/gateways/{gatewayId}/credentials/")]
  [ApiController]
  public class GatewayCredentialsController : ControllerAbstract
  {
    public GatewayCredentialsController(IUnitOfWork uow) : base(uow) { }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GatewayCredential credential, CancellationToken cancellationToken)
    {
      DefaultResponseDto<GatewayCredential> response = await UnitOfWork
          .Rules
          .GatewayCredential
          .Add(credential, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> List([FromRoute] int credentialId, CancellationToken cancellationToken)
    {
      DefaultResponseDto<IEnumerable<GatewayCredential>> response = await UnitOfWork
          .Rules
          .GatewayCredential
          .GetAll(credentialId, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      if (response.Total == 0)
        return NoContent();

      return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
      DefaultResponseDto<GatewayCredential> response = await UnitOfWork
          .Rules
          .GatewayCredential
          .Get(cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      if (response.Total == 0)
        return NoContent();

      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GatewayCredential credential, CancellationToken cancellationToken)
    {
      DefaultResponseDto<GatewayCredential> response = await UnitOfWork
          .Rules
          .GatewayCredential
          .Update(credential, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
      DefaultResponseDto<bool> response = await UnitOfWork
          .Rules
          .GatewayCredential
          .Delete(id, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

  }
}
