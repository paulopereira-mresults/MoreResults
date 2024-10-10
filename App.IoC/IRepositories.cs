using App.IoC.Repositories.Tools;

namespace App.IoC;

public partial interface IRepositories
{
  #region Repositories - Module Tools
  IShortlinkRepository Shortlink { get; set; }
  IShortlinkAccessRepository ShortlinkAccess { get; set; }
  #endregion

}
