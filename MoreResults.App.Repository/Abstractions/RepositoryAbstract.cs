using Microsoft.EntityFrameworkCore;
using MoreResults.App.Domain.Entities.Abstractions;
using MoreResults.App.Infrastructure.Contexts;
using MoreResults.App.IoC.Abstractions;

namespace MoreResults.App.Repository.Abstractions;

public class RepositoryAbstract<T>: IRepository<T> where T : EntityAbstract
{
    public DefaultContext Context { get; set; }

    public RepositoryAbstract(DefaultContext context)
    {
        Context = context;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        T? result = await Context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id);
        
        return result;
    }

    public async Task<IEnumerable<T>> ListAsync(Func<T, bool> filter)
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

    public async Task<T> AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        T? entityFound = await Context
            .Set<T>()
            .Where(x => x.Id == entity.Id)
            .FirstOrDefaultAsync();

        if (entityFound is null) return null;

        Context.Set<T>().Update(entity);
        return entity;
    }

}
