using App.Domain.Entities.Abstractions;

namespace App.IoC.Abstractions;

public interface IRepository<T> where T : EntityAbstract
{

    /// <summary>
    /// Recupera um registro a partir do seu id
    /// </summary>
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Alista registros a partir de uma expressão lambda
    /// </summary>
    Task<IEnumerable<T>> ListAsync(Func<T, bool> filter, CancellationToken cancellationToken);

    /// <summary>
    /// Alista todos os registros
    /// </summary>
    Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Salva um novo registro no banco de dados.
    /// </summary>
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Atualiza um registro no banco de dados.
    /// </summary>
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Apaga um registro no banco de dados.
    /// </summary>
    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
}
