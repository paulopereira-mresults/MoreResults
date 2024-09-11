using MoreResults.App.Infrastructure.Contexts;
using MoreResults.App.IoC;
using MoreResults.App.IoC.Repositories.Tools;
using MoreResults.App.Repository.Tools;

namespace MoreResults.App.Api;

public partial class Repositories: IRepositories
{
    #region Repositories - Module Tools
    public IShortlinkRepository Shortlink { get; private set; }
    public IShortlinkAccessRepository ShortlinkAccess { get; private set; }

    #endregion

    public Repositories(DefaultContext defaultContext)
    {
        Shortlink = new ShortlinkRepository(defaultContext);
        ShortlinkAccess = new ShortlinkAccessRepository(defaultContext);
    }
}
