using App.Infrastructure.Contexts;
using App.IoC;

namespace App.Api;

public partial class UnitOfWork : IUnitOfWork
{
  public IRules Rules { get; private set; }

  public UnitOfWork(DefaultContext defaultContext)
  {
    Rules = new Rules(defaultContext);
  }
}
