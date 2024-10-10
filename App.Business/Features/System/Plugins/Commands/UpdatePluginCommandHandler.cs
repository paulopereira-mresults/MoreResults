using App.Business.Features.Abstractions;
using App.Business.Features.System.Plugins.Validators;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;

namespace App.Business.Features.System.Plugins.Commands;

public class UpdatePluginCommandHandler : FeatureAbstract<Plugin>, IFeature<DefaultResponseDto<Plugin>, Plugin>
{
  private PluginValidator _validator = new PluginValidator();

  public UpdatePluginCommandHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<Plugin>> HandleAsync(Plugin command, CancellationToken cancellationToken)
  {
    Plugin? updatedPlugin = await Repositories.Plugin.GetByIdAsync(command.Id, cancellationToken);

    updatedPlugin.Update(command.Controller, command.Resume, command.Source, command.IsActive);

    if (_validator.ValidationForAddOrUpdate(updatedPlugin).IsValid)
      updatedPlugin = await Repositories.Plugin.AddAsync(updatedPlugin, cancellationToken);

    return DefaultResponseDto<Plugin>
        .Create(updatedPlugin)
        .AddNotifications(_validator.Notifications);
  }
}
