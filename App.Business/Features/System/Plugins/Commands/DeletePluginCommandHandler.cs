using App.Business.Features.Abstractions;
using App.Business.Features.System.Plugins.Validators;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;

namespace App.Business.Features.System.Plugins.Commands;

public class DeletePluginCommandHandler : FeatureAbstract<Plugin>, IFeature<DefaultResponseDto<bool>, int>
{
  private PluginValidator _validator = new PluginValidator();

  public DeletePluginCommandHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<bool>> HandleAsync(int id, CancellationToken cancellationToken)
  {
    Plugin? pluginFounded = await Repositories.Plugin.GetByIdAsync(id, cancellationToken);

    bool isDeleted = false;

    if (pluginFounded is not null)
    {
      isDeleted = await Repositories.Plugin.DeleteAsync(pluginFounded, cancellationToken);
    }

    return DefaultResponseDto<bool>
        .Create(isDeleted)
        .AddNotifications(_validator.Notifications);
  }
}
