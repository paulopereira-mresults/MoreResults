using App.Domain.Entities.Abstractions;
using App.Infrastructure.Contexts;
using App.IoC.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace App.Repository.Abstractions;

public class RepositoryAbstract<T> : IRepository<T> where T : EntityAbstract
{
  public DefaultContext Context { get; set; }

  public RepositoryAbstract(DefaultContext context)
  {
    Context = context;
  }

  public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
  {
    T? result = await Context
        .Set<T>()
        .FirstOrDefaultAsync(x => x.Id == id);

    return result;
  }

  public async Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken)
  {
    return await Task.Run(() =>
    {
      IEnumerable<T> result = Context
              .Set<T>()
              .ToList();

      return result;
    });
  }

  public async Task<IEnumerable<T>> ListAsync(Func<T, bool> filter, CancellationToken cancellationToken)
  {
    return await Task.Run(() =>
    {
      IEnumerable<T> result = Context
              .Set<T>()
              .Where(filter)
              .ToList();

      return result;
    });
  }

  public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
  {
    await Context.Set<T>().AddAsync(entity, cancellationToken);
    await Context.SaveChangesAsync();
    return entity;
  }

  public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
  {
    Context.Set<T>().Update(entity);
    await Context.SaveChangesAsync();
    return entity;
  }

  public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken)
  {
    Context.Set<T>().Remove(entity);
    int totalDeleted = await Context.SaveChangesAsync(cancellationToken);
    return totalDeleted > 0;
  }
}
