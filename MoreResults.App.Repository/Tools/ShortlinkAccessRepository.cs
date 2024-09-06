using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.Infrastructure.Contexts;
using MoreResults.App.IoC.Repositories.Tools;
using MoreResults.App.Repository.Abstractions;

namespace MoreResults.App.Repository.Tools;

public class ShortlinkAccessRepository : RepositoryAbstract<ShortlinkAccess>, IShortlinkAccessRepository
{
    public ShortlinkAccessRepository(DefaultContext context) : base(context)
    {
    }

}
