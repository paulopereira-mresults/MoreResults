using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;

namespace App.Business.Features.Tools.Plugins.Queries;

public class ListPluginsQueryHandler : FeatureAbstract<Plugin>, IFeature<DefaultResponseDto<IEnumerable<Plugin>>, int>
{
  public ListPluginsQueryHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<IEnumerable<Plugin>>> HandleAsync(int command, CancellationToken cancellationToken)
  {
    IEnumerable<Plugin> plugins = await Repositories.Plugin.ListAsync(cancellationToken);

    DefaultResponseDto<IEnumerable<Plugin>> response = DefaultResponseDto<IEnumerable<Plugin>>
        .Create(plugins, plugins.Count());

    return response;
  }
}
