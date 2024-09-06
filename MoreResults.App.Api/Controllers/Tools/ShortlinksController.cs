using Microsoft.AspNetCore.Mvc;
using MoreResults.App.Api.Controllers.Abstractions;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Api.Controllers.Tools;

[Route("[controller]")]
[ApiController]
public class ShortlinksController : ControllerAbstract
{
    public ShortlinksController(IUnitOfWork uow): base(uow) { }

    [HttpGet("redirect/{code}")]
    public async Task<IActionResult> RedirectTo([FromRoute] string code)
    {
        DefaultResponseDto<Shortlink> response = await UnitOfWork.Rules.Shortlink.GetByCodeAsync(code);

        if (response.IsInvalid)
            return BadRequest(response.Notifications);

        if (response.Result is null)
            return NotFound();

        return new RedirectResult(response.Result?.Link ?? "https://www.mresults.com.br");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        DefaultResponseDto<Shortlink> response = await UnitOfWork.Rules.Shortlink.GetByIdAsync(id);

        if (response.IsInvalid)
            return BadRequest(response.Notifications);

        if (response.Result is null)
            return NotFound();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Shortlink shortlink)
    {
        DefaultResponseDto<Shortlink> created = await UnitOfWork.Rules.Shortlink.AddAsync(shortlink);

        if (created.IsInvalid)
            return BadRequest(created);

        return Ok(created);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Shortlink shortlink)
    {
        DefaultResponseDto<Shortlink> updated = await UnitOfWork.Rules.Shortlink.UpdateAsync(shortlink);

        if (updated.IsInvalid)
            return BadRequest(updated);

        return Ok(updated);
    }
}
