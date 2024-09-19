using App.Api.Controllers.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.System;

[Route("system/[controller]")]
[ApiController]
public class PluginsController : ControllerAbstract
{
    public PluginsController(IUnitOfWork uow) : base(uow)
    {
    }

    /// <summary>
    /// Alista todos os plugins disponíveis
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        DefaultResponseDto<IEnumerable<Plugin>> response = await UnitOfWork
            .Rules
            .Plugin
            .ListAsync(cancellationToken);

        if (!response.Result.Any())
            return NoContent();

        return Ok(response);
    }

    /// <summary>
    /// Recupera as informações de um plugin específico a partir de um ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        DefaultResponseDto<IEnumerable<Plugin>> response = await UnitOfWork
            .Rules
            .Plugin
            .ListAsync(cancellationToken);

        if (!response.Result.Any())
            return NotFound();

        return Ok(response);
    }

    /// <summary>
    /// Adiciona um novo plugin.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Plugin plugin, CancellationToken cancellationToken)
    {
        DefaultResponseDto<Plugin> created = await UnitOfWork.Rules.Plugin.AddAsync(plugin, cancellationToken);

        if (created.IsInvalid)
            return BadRequest(created);

        return Ok(created);
    }

    /// <summary>
    /// Atualiza os dados de um link já cadastrado.
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Plugin plugin, CancellationToken cancellationToken)
    {
        DefaultResponseDto<Plugin> updated = await UnitOfWork.Rules.Plugin.UpdateAsync(plugin, cancellationToken);

        if (updated.IsInvalid)
            return BadRequest(updated);

        return Ok(updated);
    }

    /// <summary>
    /// Apaga um registro link encurtado a partir do ID informado.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        DefaultResponseDto<bool> deleted = await UnitOfWork
            .Rules
            .Plugin
            .DeleteAsync(id, cancellationToken);

        if (deleted.IsInvalid)
            return BadRequest(deleted);

        return StatusCode(StatusCodes.Status410Gone, deleted);
    }
}
