using App.Business.Rules.System;
using App.Business.Rules.Tools;
using App.Infrastructure.Contexts;
using App.IoC;
using App.IoC.Rules.System;
using App.IoC.Rules.Tools;

namespace App.Api;

public partial class Rules: IRules
{
    private readonly IRepositories _repositories;

    #region Business - Module Tools
    public IShortlinkBusiness Shortlink { get; }

    public IGatewayCategoryBusiness GatewayCategory { get; }
    public IGatewayParameterBusiness GatewayParameter { get; }
    public IGatewayBusiness Gateway { get; }
    public IGatewayCredentialBusiness GatewayCredential { get; }
    #endregion


    #region Business - Module System
    public IPluginBusiness Plugin { get; }
    #endregion

    public Rules(DefaultContext context)
    {
        _repositories = new Repositories(context);

        #region Business - Module Tools
        Shortlink = new ShortlinkBusiness(_repositories);

        GatewayCategory = new GatewayCategoryBusiness(_repositories);
        GatewayParameter = new GatewayParameterBusiness(_repositories);
        Gateway = new GatewayBusiness(_repositories);
        GatewayCredential = new GatewayCredentialBusiness(_repositories);
        #endregion


        #region Business - Module System
        Plugin = new PluginBusiness(_repositories);
        #endregion
    }
}
