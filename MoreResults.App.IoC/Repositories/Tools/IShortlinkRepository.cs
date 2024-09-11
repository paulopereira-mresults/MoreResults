using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC.Abstractions;

namespace MoreResults.App.IoC.Repositories.Tools;

public interface IShortlinkRepository : IRepository<Shortlink>
{
    Task<Shortlink?> GetByCodeAsync(string code, CancellationToken cancellationToken);
}
