namespace MoreResults.App.Business.Interfaces;

public interface IFeature<TResult, TCommand>
{
    Task<TResult> Handle(TCommand command);
}