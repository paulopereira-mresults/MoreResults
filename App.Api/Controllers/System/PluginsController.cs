using App.Api.Controllers.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.System;

[Route("[controller]")]
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
            .List(cancellationToken);

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
            .List(cancellationToken);

        if (!response.Result.Any())
            return NotFound();

        return Ok(response);
    }
}
