using App.IoC;
using App.IoC.Repositories.System;
using App.IoC.Repositories.Tools;
using App.Test.App_Repository.Repositories;

namespace App.Test.App_Repository;

public class RepositoriesMock : IRepositories
{
    public IShortlinkRepository Shortlink { get; private set; }

    public IShortlinkAccessRepository ShortlinkAccess { get; private set; }

    public IPluginRepository Plugin { get; private set; }

    public RepositoriesMock()
    {
        Shortlink = new ShortlinkRepositoryMock().Mock;
        ShortlinkAccess = new ShortlinkAccessRepositoryMock().Mock;
    }
}
