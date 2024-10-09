using App.Api.Controllers.Abstractions;
using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class StartupController : ControllerAbstract
{
  public StartupController(IUnitOfWork uow) : base(uow) { }

  [HttpGet("/")]
  public async Task<IActionResult> Up()
  {
    Plugins.ExecuteBefore(nameof(StartupController), null);

    DateTime? date = DateTime.Now;
    return Ok($"Bem vindo(a). Hoje é {date:g}");
  }
}
