using Microsoft.EntityFrameworkCore;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.Infrastructure.Contexts;
using MoreResults.App.IoC.Repositories.Tools;
using MoreResults.App.Repository.Abstractions;

namespace MoreResults.App.Repository.Tools;

public class ShortlinkRepository : RepositoryAbstract<Shortlink>, IShortlinkRepository
{
    public ShortlinkRepository(DefaultContext context) : base(context)
    {
    }

    public async Task<Shortlink?> GetByCodeAsync(string code) 
        => await Context.Shortlinks.FirstOrDefaultAsync(x => x.Code == code);
}
