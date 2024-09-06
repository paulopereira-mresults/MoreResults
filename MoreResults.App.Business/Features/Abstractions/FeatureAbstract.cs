using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Abstractions;

public abstract class FeatureAbstract<T>
{
    protected IRepositories Repositories { get; }
    protected IRules Rules { get; }

    protected FeatureAbstract(IRules rules, IRepositories repositories)
    {
        Repositories = repositories;
        Rules = rules;
    }
    protected FeatureAbstract(IRepositories repositories)
    {
        Repositories = repositories;
    }

    protected FeatureAbstract(IRules rules)
    {
        Rules = rules;
    }

}
