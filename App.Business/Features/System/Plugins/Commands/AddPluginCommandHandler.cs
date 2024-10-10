using App.Business.Features.Abstractions;
using App.Business.Features.System.Plugins.Validators;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;

namespace App.Business.Features.System.Plugins.Commands;

public class AddPluginCommandHandler : FeatureAbstract<Plugin>, IFeature<DefaultResponseDto<Plugin>, Plugin>
{
  private PluginValidator _validator = new PluginValidator();

  public AddPluginCommandHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<Plugin>> HandleAsync(Plugin command, CancellationToken cancellationToken)
  {
    Plugin addedPlugin = new Plugin(command.Controller, command.Resume, command.Source);

    if (_validator.ValidationForAddOrUpdate(addedPlugin).IsValid)
      addedPlugin = await Repositories.Plugin.AddAsync(addedPlugin, cancellationToken);

    return DefaultResponseDto<Plugin>
        .Create(addedPlugin)
        .AddNotifications(_validator.Notifications);
  }
}
