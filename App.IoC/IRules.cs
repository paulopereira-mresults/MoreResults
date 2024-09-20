using App.IoC.Rules.System;
using App.IoC.Rules.Tools;

namespace App.IoC;

public partial interface IRules
{
    #region Business - Module Tools
    IShortlinkBusiness Shortlink { get; }

    IGatewayCategoryBusiness GatewayCategory { get; }
    IGatewayBusiness Gateway { get; }
    #endregion

    #region Business - Module System
    IPluginBusiness Plugin { get; }
    #endregion
}
