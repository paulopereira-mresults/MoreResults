using App.IoC;
using App.Test.App_Repository;

namespace App.Test.App_Business;

public abstract class AbstractTest
{
  protected IRepositories _repositories = new RepositoriesMock();
}
