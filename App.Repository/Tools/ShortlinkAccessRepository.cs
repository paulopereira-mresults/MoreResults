using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class ShortlinkAccessRepository : RepositoryAbstract<ShortlinkAccess>, IShortlinkAccessRepository
{
  public ShortlinkAccessRepository(DefaultContext context) : base(context)
  {
  }

}
