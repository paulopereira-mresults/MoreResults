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
        public GatewayController(IUnitOfWork uow) : base(uow)
        {
        }

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
        /// Alista todas as categorias cadastradas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            DefaultResponseDto<IEnumerable<GatewayCategory>> response = await  UnitOfWork
                .Rules
                .GatewayCategory
                .GetAll(cancellationToken);

            if (response.IsInvalid)
                return BadRequest(response);

            if (response.Total == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            DefaultResponseDto<GatewayCategory> response = await UnitOfWork
                .Rules
                .GatewayCategory
                .Get(cancellationToken);

            if (response.IsInvalid)
                return BadRequest(response);

            if (response.Total == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GatewayCategory category, CancellationToken cancellationToken)
        {
            DefaultResponseDto<GatewayCategory> response = await UnitOfWork
                .Rules
                .GatewayCategory
                .Update(category, cancellationToken);

            if (response.IsInvalid)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            DefaultResponseDto<bool> response = await UnitOfWork
                .Rules
                .GatewayCategory
                .Delete(id, cancellationToken);

            if (response.IsInvalid)
                return BadRequest(response);

            return Ok(response);
        }

    }
}
