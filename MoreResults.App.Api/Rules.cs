using MoreResults.App.Business.Rules;
using MoreResults.App.Infrastructure.Contexts;
using MoreResults.App.IoC;
using MoreResults.App.IoC.Rules.Tools;

namespace MoreResults.App.Api;

public partial class Rules: IRules
{
    private readonly IRepositories _repositories;

    #region Business - Module Tools
    public IShortlinkBusiness Shortlink { get; }
    #endregion

    public Rules(DefaultContext context)
    {
        _repositories = new Repositories(context);

        Shortlink = new ShortlinkBusiness(_repositories);
    }
}
