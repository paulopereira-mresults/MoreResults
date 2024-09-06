using MoreResults.App.Domain.Entities.Abstractions;

namespace MoreResults.App.IoC.Abstractions;

public interface IRepository<T> where T : EntityAbstract
{

    /// <summary>
    /// Recupera um registro a partir do seu id
    /// </summary>
    Task<T?> GetById(int id);

    /// <summary>
    /// Alista registros a partir de uma expressão lambda
    /// </summary>
    Task<IEnumerable<T>> List(Func<T, bool> filter);

    /// <summary>
    /// Salva um novo registro no banco de dados.
    /// </summary>
    Task<T> Add(T entity);

    /// <summary>
    /// Atualiza um registro no banco de dados.
    /// </summary>
    Task<T> Update(T entity);
}
