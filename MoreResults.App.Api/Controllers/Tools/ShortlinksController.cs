using Microsoft.AspNetCore.Mvc;
using MoreResults.App.Api.Controllers.Abstractions;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Api.Controllers.Tools;

[Route("/")]
[ApiController]
public class ShortlinksController : ControllerAbstract
{
    public ShortlinksController(IUnitOfWork uow): base(uow) { }

    [HttpGet("{code}")]
    public async Task<IActionResult> RedirectTo([FromRoute] string code)
    {
        Shortlink? shortlink = await UnitOfWork.Rules.Shortlink.GetByCodeAsync(code);

        if (shortlink is null)
            return NotFound();

        return new RedirectResult(shortlink?.Link ?? "https://www.dotcreative.com.br");
    }
}
