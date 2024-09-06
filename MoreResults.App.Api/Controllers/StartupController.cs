using Microsoft.AspNetCore.Mvc;

namespace MoreResults.App.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class StartupController : ControllerBase
{
    [HttpGet("/")]
    public async Task<IActionResult> Up()
    {
        DateTime? date = DateTime.Now;
        return Ok($"Bem vindo(a). Hoje é {date:g}");
    }
}
