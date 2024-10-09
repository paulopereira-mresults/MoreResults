using App.Domain.Entities.Abstractions;
using App.Domain.Interfaces;

namespace App.Domain.Entities.Core;

public class Company : EntityAbstract, IUpdatable<Company>
{
  public string FantasyName { get; set; }
  public string JuridicalName { get; set; }

  protected Company()
  {

  }

  public Company(string fantasyName, string juridicalName)
  {
    FantasyName = fantasyName;
    JuridicalName = juridicalName;
  }

  public void Update(Company company)
  {
    FantasyName = company.FantasyName;
    JuridicalName= company.JuridicalName;
  }
}
