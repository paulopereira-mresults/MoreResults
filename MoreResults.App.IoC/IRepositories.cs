using MoreResults.App.IoC.Repositories.Tools;

namespace MoreResults.App.IoC;

public partial interface IRepositories
{
    #region Repositories - Module Basic
    IShortlinkRepository Shortlink { get; }
    #endregion

}
