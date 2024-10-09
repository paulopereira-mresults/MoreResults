using App.Domain.Entities.System;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.System;
using App.Repository.Abstractions;

namespace App.Repository.System;

public class PluginRepository : RepositoryAbstract<Plugin>, IPluginRepository
{
  public PluginRepository(DefaultContext context) : base(context)
  {
  }
}
