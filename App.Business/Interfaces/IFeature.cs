namespace App.Business.Interfaces;

public interface IFeature<TResult, TCommand>
{
  Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}