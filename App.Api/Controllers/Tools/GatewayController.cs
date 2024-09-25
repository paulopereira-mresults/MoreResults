using App.Api.Controllers.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.Tools
{
  [Route("tools/gateways")]
  [ApiController]
  public class GatewayController : ControllerAbstract
  {
    public GatewayController(IUnitOfWork uow) : base(uow) { }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Gateway gateway, CancellationToken cancellationToken)
    {
      DefaultResponseDto<Gateway> response = await UnitOfWork
          .Rules
          .Gateway
          .Add(gateway, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    /// <summary>
    /// Alista todas os gateways cadastrados.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
      DefaultResponseDto<IEnumerable<Gateway>> response = await UnitOfWork
          .Rules
          .Gateway
          .GetAll(cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      if (response.Total == 0)
        return NoContent();

      return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
      DefaultResponseDto<Gateway> response = await UnitOfWork
          .Rules
          .Gateway
          .Get(cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      if (response.Total == 0)
        return NoContent();

      return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Gateway gateway, CancellationToken cancellationToken)
    {
      DefaultResponseDto<Gateway> response = await UnitOfWork
          .Rules
          .Gateway
          .Update(gateway, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
      DefaultResponseDto<bool> response = await UnitOfWork
          .Rules
          .Gateway
          .Delete(id, cancellationToken);

      if (response.IsInvalid)
        return BadRequest(response);

      return Ok(response);
    }

    /// <summary>
    /// Este endpoint deve ser usando quando a requisição envolver exclusivamente a busca, exibição ou listagem de dados.
    /// </summary>
    /// <param name="code">Código do gateway</param>
    /// <param name="parameters">Parâmetros para requisição.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição</param>
    /// <returns></returns>
    [HttpGet("{code}")]
    public async Task<IActionResult> ExecuteGet([FromRoute] string code, [FromQuery] dynamic parameters, CancellationToken cancellationToken)
    {
      var response = await UnitOfWork
          .Rules
          .Gateway
          .Execute(HttpMethod.Get, code, parameters, cancellationToken);

      return Ok();
    }

    /// <summary>
    /// Este endpoint deve ser usando quando a requisição envolver exclusivamente o salvamento de novos dados.
    /// </summary>
    /// <param name="code">Código do gateway</param>
    /// <param name="parameters">Parâmetros para requisição.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição</param>
    /// <returns></returns>
    [HttpPost("{code}")]
    public async Task<IActionResult> ExecutePost([FromRoute] string code, [FromBody] dynamic parameters, CancellationToken cancellationToken)
    {
      var response = await UnitOfWork
          .Rules
          .Gateway
          .Execute(HttpMethod.Post, code, parameters, cancellationToken);

      return Ok();
    }

    /// <summary>
    /// Este endpoint deve ser usando quando a requisição envolver exclusivamente a atualização dados.
    /// </summary>
    /// <param name="code">Código do gateway</param>
    /// <param name="parameters">Parâmetros para requisição.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição</param>
    /// <returns></returns>
    [HttpPut("{code}")]
    public async Task<IActionResult> ExecutePut([FromRoute] string code, [FromBody] dynamic parameters, CancellationToken cancellationToken)
    {
      var response = await UnitOfWork
          .Rules
          .Gateway
          .Execute(HttpMethod.Put, code, parameters, cancellationToken);

      return Ok();
    }

    /// <summary>
    /// Este endpoint deve ser usando quando a requisição envolver exclusivamente a deleção de dados.
    /// </summary>
    /// <param name="code">Código do gateway</param>
    /// <param name="parameters">Parâmetros para requisição.</param>
    /// <param name="cancellationToken">Token de cancelamento da requisição</param>
    /// <returns></returns>
    [HttpDelete("{code}")]
    public async Task<IActionResult> ExecuteDelete([FromRoute] string code, [FromBody] dynamic parameters, CancellationToken cancellationToken)
    {
      var response = await UnitOfWork
          .Rules
          .Gateway
          .Execute(HttpMethod.Delete, code, parameters, cancellationToken);

      return Ok();
    }
  }
}
