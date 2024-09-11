using App.Infrastructure.Contexts;
using App.IoC;
using App.IoC.Repositories.Tools;
using App.Repository.Tools;

namespace App.Api;

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
