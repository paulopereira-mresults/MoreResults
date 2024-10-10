using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class ShortlinkAccessRepository(DefaultContext context) : RepositoryAbstract<ShortlinkAccess>(context), IShortlinkAccessRepository
{
}
