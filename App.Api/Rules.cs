using App.Business.Rules.Tools;
using App.Infrastructure.Contexts;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Api;

public partial class Rules : IRules
{
  private readonly IRepositories _repositories;

  #region Business - Module Tools
  public IShortlinkBusiness Shortlink { get; }
  #endregion

  public Rules(DefaultContext context)
  {
    _repositories = new Repositories(context);

    #region Business - Module Tools
    Shortlink = new ShortlinkBusiness(_repositories);
    #endregion
  }
}
