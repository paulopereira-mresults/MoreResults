using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace App.Repository.Tools;

public class ShortlinkRepository(DefaultContext context) : RepositoryAbstract<Shortlink>(context), IShortlinkRepository
{
  public async Task<Shortlink?> GetByCodeAsync(string code, CancellationToken cancellationToken)
      => await Context.Shortlinks.FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
}
