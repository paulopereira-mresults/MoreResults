using App.Infrastructure.Contexts;
using App.IoC;
using App.IoC.Repositories.System;
using App.IoC.Repositories.Tools;
using App.Repository.System;
using App.Repository.Tools;

namespace App.Api;

public partial class Repositories : IRepositories
{
    #region Repositories - Module Tools
    public IShortlinkRepository Shortlink { get; private set; }
    public IShortlinkAccessRepository ShortlinkAccess { get; private set; }

    public IGatewayRepository Gateway { get; private set; }
    public IGatewayCategoryRepository GatewayCategory { get; private set; }
    public IGatewayParameterRepository GatewayParameter { get; private set; }
    public IGatewayScheduleRepository GatewaySchedule { get; private set; }
    #endregion

    #region Repositorie - Module System
    public IPluginRepository Plugin { get; private set; }
    #endregion

    public Repositories(DefaultContext defaultContext)
    {
        #region Repositories - Module Tools
        Shortlink = new ShortlinkRepository(defaultContext);
        ShortlinkAccess = new ShortlinkAccessRepository(defaultContext);

        Gateway = new GatewayRepository(defaultContext);
        GatewayCategory = new GatewayCategoryRepository(defaultContext);
        GatewayParameter = new GatewayParameterRepository(defaultContext);
        GatewaySchedule = new GatewayScheduleRepository(defaultContext);
        #endregion

        #region Repositorie - Module System
        Plugin = new PluginRepository(defaultContext);
        #endregion
    }
}
