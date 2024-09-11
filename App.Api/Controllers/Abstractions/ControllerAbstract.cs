using Microsoft.AspNetCore.Mvc;
using App.IoC;
using App.Services.Plugins;

namespace App.Api.Controllers.Abstractions;

[Route("api/[controller]")]
[ApiController]
public abstract class ControllerAbstract : ControllerBase
{
    public readonly PluginExecution Plugins;

    public IUnitOfWork UnitOfWork { get; private set; }

    protected ControllerAbstract(IUnitOfWork uow)
    {
        UnitOfWork = uow;
        Plugins = new PluginExecution(@"C:\MorePlugins");
    }

}
