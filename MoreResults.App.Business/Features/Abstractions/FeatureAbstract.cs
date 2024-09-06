using MoreResults.App.Business.Interfaces;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Abstractions;

public abstract class FeatureAbstract<T>
{
    protected IRepositories Repositories { get; }
    protected IRules Rules { get; }
    protected IValidatable<T> Validation { get; }

    protected FeatureAbstract(IRules rules, IRepositories repositories)
    {
        Repositories = repositories;
        Rules = rules;
    }
    protected FeatureAbstract(IRepositories repositories)
    {
        Repositories = repositories;
    }
    protected FeatureAbstract(IRepositories repositories, IValidatable<T> validation)
    {
        Repositories = repositories;
        Validation = validation;
    }

    protected FeatureAbstract(IRules rules, IRepositories repositories, IValidatable<T> validation)
    {
        Repositories = repositories;
        Rules = rules;
        Validation = validation;
    }

    protected FeatureAbstract(IRules rules)
    {
        Rules = rules;
    }

    protected FeatureAbstract(IRules rules, IValidatable<T> validation)
    {
        Rules = rules;
        Validation = validation;
    }
}
