using App.Domain.Entities.Abstractions;
using App.Domain.Interfaces;

namespace App.Domain.Entities.Core;

public class Person : EntityAbstract, IUpdatable<Person>
{
  public void Update(Person person)
  {
    NamePrincipal = person.NamePrincipal;
    NameAlternative = person.NameAlternative;
  }

  public Person(string namePrincipal, string nameAlternative)
  {
    NamePrincipal = namePrincipal;
    NameAlternative = nameAlternative;
  }

  public string NamePrincipal { get; set; }
  public string NameAlternative { get; set; }
}
