using App.Api.Controllers.Abstractions;
using App.IoC;
using App.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiExplorerSettings(GroupName = nameof(SystemModules.CORE))]
[Route("[controller]")]
[ApiController]
public class StartupController : ControllerAbstract
{
  public StartupController(IUnitOfWork uow) : base(uow) { }

  [HttpGet]
  public async Task<IActionResult> Up()
  {
    Plugins.ExecuteBefore(nameof(StartupController), null);

    DateTime? date = DateTime.Now;
    return Ok($"Bem vindo(a). Hoje é {date:g}");
  }

  [Authorize]
  [HttpGet("with-auth")]
  public async Task<IActionResult> UpWithAuth()
  {
    Plugins.ExecuteBefore(nameof(StartupController), null);

    DateTime? date = DateTime.Now;
    return Ok($"Bem vindo(a). Hoje é {date:g}");
  }
}
