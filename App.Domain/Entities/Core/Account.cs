using App.Domain.Entities.Abstractions;
using App.Domain.Interfaces;

namespace App.Domain.Entities.Core;

public class Account : EntityAbstract, IUpdatable<Account>
{
  public string Name { get; set; }
  public string FantasyName { get; set; }

  public Account(string name, string fantasyName)
  {
    Name = name;
    FantasyName = fantasyName;
  }

  public void Update(Account entity)
  {
    Name = entity.Name;
    FantasyName = entity.FantasyName;
  }
}
