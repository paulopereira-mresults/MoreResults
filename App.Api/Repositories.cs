using App.Infrastructure.Contexts;
using App.IoC;
using App.IoC.Repositories.Core;
using App.IoC.Repositories.System;
using App.IoC.Repositories.Tools;
using App.Repository.Core;
using App.Repository.System;
using App.Repository.Tools;

namespace App.Api;

public partial class Repositories : IRepositories
{
  #region Repositories - Module Core
  public IAccountRepository AccountRepository { get; private set; }
  #endregion

  #region Repositories - Module Tools
  public IShortlinkRepository Shortlink { get; private set; }
  public IShortlinkAccessRepository ShortlinkAccess { get; private set; }

  #endregion

  #region Repositorie - Module System
  public IPluginRepository Plugin { get; private set; }
  #endregion

  public Repositories(DefaultContext defaultContext)
  {
    #region Repositories - Module Core
    AccountRepository = new AccountRepository(defaultContext);
    #endregion

    #region Repositories - Module Tools
    Shortlink = new ShortlinkRepository(defaultContext);
    ShortlinkAccess = new ShortlinkAccessRepository(defaultContext);
    #endregion

    #region Repositorie - Module System
    Plugin = new PluginRepository(defaultContext);
    #endregion
  }
}
