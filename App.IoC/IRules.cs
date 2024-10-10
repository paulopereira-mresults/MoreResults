using App.IoC.Rules.Tools;

namespace App.IoC;

public partial interface IRules
{
  #region Business - Module Tools
  IShortlinkBusiness Shortlink { get; }
  #endregion
}
