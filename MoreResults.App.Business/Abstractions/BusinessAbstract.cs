using MoreResults.App.IoC;
using MoreResults.App.IoC.Abstractions;

namespace MoreResults.App.Business.Abstractions;

public class BusinessAbstract : IBusiness
{
    public IRepositories Repositories { get; set; }

    public BusinessAbstract(IRepositories repositories)
    {
        Repositories = repositories;
    }
}
