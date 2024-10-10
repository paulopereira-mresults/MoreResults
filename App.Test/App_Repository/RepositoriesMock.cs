using App.IoC;
using App.IoC.Repositories.Tools;

namespace App.Test.App_Repository;

public class RepositoriesMock : IRepositories
{
  public IShortlinkRepository Shortlink { get; set; }

  public IShortlinkAccessRepository ShortlinkAccess { get; set; }

}
