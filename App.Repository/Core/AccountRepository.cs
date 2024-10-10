using App.Domain.Entities.Core;
using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Core;
using App.Repository.Abstractions;

namespace App.Repository.Core;

public class AccountRepository : RepositoryAbstract<Account>, IAccountRepository
{
  public AccountRepository(DefaultContext context) : base(context)
  {
  }
}
