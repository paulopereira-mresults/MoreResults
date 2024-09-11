using Microsoft.AspNetCore.Mvc;
using MoreResults.App.Api.Controllers.Abstractions;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Api.Controllers.Tools;

/// <summary>
/// Controla o fluxo de links encurtados: listar, exibir, atualizar e apagar.
/// </summary>
[Route("[controller]")]
[ApiController]
public class ShortlinksController : ControllerAbstract
{
    public ShortlinksController(IUnitOfWork uow): base(uow) { }

    /// <summary>
    /// Alista os links existentes
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        DefaultResponseDto<IEnumerable<Shortlink>> response = await UnitOfWork
            .Rules
            .Shortlink
            .List(cancellationToken);

        if (response.IsInvalid)
            return BadRequest(response.Notifications);

        if (response.Result is null || response.Total == 0)
            return NoContent();

        return Ok(response);
    }

    /// <summary>
    /// Redireciona o usuário para o link informado através do código.
    /// </summary>
    [HttpGet("/{code}")]
    public async Task<IActionResult> RedirectTo([FromRoute] string code, CancellationToken cancellationToken)
    {
        DefaultResponseDto<Shortlink> response = await UnitOfWork.Rules.Shortlink.GetByCodeAsync(code, cancellationToken);

        if (response.IsInvalid)
            return BadRequest(response.Notifications);

        if (response.Result is null)
            return NotFound("Link não encontrado.");

        return new RedirectResult(response.Result?.Link ?? "https://www.mresults.com.br");
    }

    /// <summary>
    /// Recupera um link a partir do ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        DefaultResponseDto<Shortlink> response = await UnitOfWork.Rules.Shortlink.GetByIdAsync(id, cancellationToken);

        if (response.IsInvalid)
            return BadRequest(response.Notifications);

        if (response.Result is null)
            return NotFound();

        return Ok(response);
    }

    /// <summary>
    /// Adiciona um novo link.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Shortlink shortlink, CancellationToken cancellationToken)
    {
        DefaultResponseDto<Shortlink> created = await UnitOfWork.Rules.Shortlink.AddAsync(shortlink, cancellationToken);

        if (created.IsInvalid)
            return BadRequest(created);

        return Ok(created);
    }

    /// <summary>
    /// Atualiza os dados de um link já cadastrado.
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Shortlink shortlink, CancellationToken cancellationToken)
    {
        DefaultResponseDto<Shortlink> updated = await UnitOfWork.Rules.Shortlink.UpdateAsync(shortlink, cancellationToken);

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
            .Shortlink
            .DeleteAsync(id, cancellationToken);

        if (deleted.IsInvalid)
            return BadRequest(deleted);

        return StatusCode(StatusCodes.Status410Gone, deleted);
    }
}
