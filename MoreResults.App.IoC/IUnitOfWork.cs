using MoreResults.App.Infrastructure.Contexts;

namespace MoreResults.App.IoC;

public interface IUnitOfWork
{
    /// <summary>
    /// Conjunto de regras de negócio
    /// </summary>
    IRules Rules { get; }
}
