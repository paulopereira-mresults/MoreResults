using MoreResults.App.Infrastructure.Contexts;
using MoreResults.App.IoC;

namespace MoreResults.App.Api;

public partial class UnitOfWork: IUnitOfWork
{
    public IRules Rules { get; private set; }

    public UnitOfWork(DefaultContext defaultContext)
    {
        Rules = new Rules(defaultContext);
    }
}
