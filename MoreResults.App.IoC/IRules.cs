using MoreResults.App.IoC.Rules.Tools;

namespace MoreResults.App.IoC;

public partial interface IRules
{
    #region Business - Module Tools
    IShortlinkBusiness Shortlink { get; }
    #endregion
}
