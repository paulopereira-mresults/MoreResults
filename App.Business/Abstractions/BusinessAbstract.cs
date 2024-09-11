using App.IoC;
using App.IoC.Abstractions;

namespace App.Business.Abstractions;

public class BusinessAbstract : IBusiness
{
    public IRepositories Repositories { get; set; }

    public BusinessAbstract(IRepositories repositories)
    {
        Repositories = repositories;
    }
}
