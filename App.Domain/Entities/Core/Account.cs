using App.Domain.Entities.Abstractions;
using App.Domain.Interfaces;

namespace App.Domain.Entities.Core;

public class Account : EntityAbstract, IUpdatable<Account>
{
  public string JuridicalName { get; set; }
  public string FantasyName { get; set; }

  public void Update(Account entity)
  {
    JuridicalName = entity.JuridicalName;
    FantasyName = entity.FantasyName;
  }
}
