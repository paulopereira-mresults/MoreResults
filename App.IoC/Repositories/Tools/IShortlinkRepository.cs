using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Repositories.Tools;

public interface IShortlinkRepository : IRepository<Shortlink>
{
  Task<Shortlink?> GetByCodeAsync(string code, CancellationToken cancellationToken);
}
