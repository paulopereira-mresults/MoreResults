using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;

namespace App.Business.Features.System.Plugins.Queries;

public class GetPluginByIdQueryHandler : FeatureAbstract<Plugin>, IFeature<DefaultResponseDto<Plugin>, int>
{
  public GetPluginByIdQueryHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<Plugin>> Handle(int command, CancellationToken cancellationToken)
  {
    Plugin? plugin = await Repositories.Plugin.GetByIdAsync(command, cancellationToken);
    return DefaultResponseDto<Plugin>.Create(plugin);
  }
}
