using App.Api.Controllers.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.Tools
{
    [Route("tools/[controller]")]
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
            DefaultResponseDto<IEnumerable<Gateway>> response = await  UnitOfWork
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
        /// Executa um endpoint que para requisições GET.
        /// </summary>
        [HttpGet("{code}")]
        [HttpPost("{code}")]
        [HttpPut("{code}")]
        [HttpDelete("{code}")]
        public async Task<IActionResult> Execute([FromRoute] string code, [FromQuery] dynamic query, CancellationToken cancellationToken)
        {
            var response = await UnitOfWork
                .Rules
                .Gateway
                .Execute(code, query, cancellationToken);

            return Ok();
        }
    }
}
