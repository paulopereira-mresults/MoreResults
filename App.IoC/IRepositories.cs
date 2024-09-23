using App.IoC.Repositories.System;
using App.IoC.Repositories.Tools;

namespace App.IoC;

public partial interface IRepositories
{
    #region Repositories - Module Tools
    IShortlinkRepository Shortlink { get; }
    IShortlinkAccessRepository ShortlinkAccess { get; }

    IGatewayCategoryRepository GatewayCategory { get; }
    IGatewayRepository Gateway { get; }
    IGatewayCredentialRepository GatewayCredential { get; }
    IGatewayParameterRepository GatewayParameter { get; }
    #endregion

    #region Repositories - Module System
    IPluginRepository Plugin { get; }
    #endregion
}
