using App.Infrastructure.Contexts;
using App.IoC;
using App.IoC.Repositories.Tools;
using App.Repository.Tools;

namespace App.Api;

public partial class Repositories : IRepositories
{
  #region Repositories - Module Tools
  public IShortlinkRepository Shortlink { get; set; }
  public IShortlinkAccessRepository ShortlinkAccess { get; set; }
  #endregion

  public Repositories(DefaultContext defaultContext)
  {
    #region Repositories - Module Tools
    Shortlink = new ShortlinkRepository(defaultContext);
    ShortlinkAccess = new ShortlinkAccessRepository(defaultContext);
    #endregion
  }
}
