using App.Infrastructure.Contexts;

namespace App.IoC;

public interface IUnitOfWork
{
    /// <summary>
    /// Conjunto de regras de negócio
    /// </summary>
    IRules Rules { get; }

}
