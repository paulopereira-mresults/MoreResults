using App.Domain.Entities.Core;
using App.Infrastructure.Contexts;
using App.Repository.Abstractions;

namespace App.Repository.Core;

public class AccountRepository(DefaultContext context) : RepositoryAbstract<Account>(context)
{
}
