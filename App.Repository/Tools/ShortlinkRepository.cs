using Microsoft.EntityFrameworkCore;
using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class ShortlinkRepository : RepositoryAbstract<Shortlink>, IShortlinkRepository
{
    public ShortlinkRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<Shortlink?> GetByCodeAsync(string code, CancellationToken cancellationToken) 
        => await Context.Shortlinks.FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
}
