using App.Api.Controllers.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.Tools
{
  [Route("tools/gateways/{gatewayId}/parameters")]
  [ApiController]
  public class GatewayParametersController : ControllerAbstract
  {
    public GatewayParametersController(IUnitOfWork uow) : base(uow)
    {
    }

    [HttpGet]
    public async Task<IActionResult> List([FromRoute] int gatewayId, CancellationToken cancellationToken)
    {
      DefaultResponseDto<IEnumerable<GatewayParameter>> response = await UnitOfWork
          .Rules
          .GatewayParameter
          .ListAllByGateway(gatewayId, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      if (response.Total == 0)
        return NoContent();

      return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
      DefaultResponseDto<GatewayParameter> response = await UnitOfWork
          .Rules
          .GatewayParameter
          .GetById(id, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      if (response.Total == 0)
        return NoContent();

      return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GatewayParameter parameter, CancellationToken cancellationToken)
    {
      DefaultResponseDto<GatewayParameter> response = await UnitOfWork
          .Rules
          .GatewayParameter
          .Add(parameter, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] GatewayParameter parameter, CancellationToken cancellationToken)
    {
      DefaultResponseDto<GatewayParameter> response = await UnitOfWork
          .Rules
          .GatewayParameter
          .Update(parameter, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
      DefaultResponseDto<bool> response = await UnitOfWork
          .Rules
          .GatewayParameter
          .Delete(id, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

  }
}
