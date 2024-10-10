using App.IoC;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers.Abstractions;

[Route("api/[controller]")]
[ApiController]
public abstract class ControllerAbstract : ControllerBase
{
  public IUnitOfWork UnitOfWork { get; private set; }

  protected ControllerAbstract(IUnitOfWork uow)
  {
    UnitOfWork = uow;
  }

}
