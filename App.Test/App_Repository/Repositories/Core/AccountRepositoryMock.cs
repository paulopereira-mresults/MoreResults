using App.Domain.Entities.Core;
using App.Repository.Core;
using Bogus;
using Moq;

namespace App.Test.App_Repository.Repositories.Core;

public class AccountRepositoryMock : AbstractMock<AccountRepository>
{
  public AccountRepositoryMock WithMany(int quantity = 10)
  {
    IEnumerable<Account> accounts = new Faker<Account>()
      .RuleFor(x => x.Id, 1)
      .RuleFor(x => x.Name, f => f.Company.CompanyName())
      .RuleFor(x => x.FantasyName, f => f.Company.CompanyName())
      .RuleFor(x => x.CreateDate, DateTime.Now.AddDays(-20))
      .RuleFor(x => x.UpdateDate, DateTime.Now.AddDays(-10))
      .Generate(quantity);

    _mock.Setup(x => x.ListAsync(CancellationToken.None).Result).Returns(accounts);

    return this;
  }

  public AccountRepositoryMock WithOne()
  {
    Account account = new Faker<Account>()
      .RuleFor(x => x.Id, 1)
      .RuleFor(x => x.Name, f => f.Company.CompanyName())
      .RuleFor(x => x.FantasyName, f => f.Company.CompanyName())
      .RuleFor(x => x.CreateDate, DateTime.Now.AddDays(-20))
      .RuleFor(x => x.UpdateDate, DateTime.Now.AddDays(-10))
      .Generate();

    _mock.Setup(x => x.GetByIdAsync(It.IsAny<int>(), CancellationToken.None).Result).Returns(account);

    return this;
  }

}
