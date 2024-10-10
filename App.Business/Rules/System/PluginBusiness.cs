using App.Business.Abstractions;
using App.Business.Features.System.Plugins.Commands;
using App.Business.Features.System.Plugins.Queries;
using App.Business.Features.Tools.Plugins.Queries;
using App.Domain.Dto;
using App.Domain.Entities.System;
using App.IoC;
using App.IoC.Rules.System;

namespace App.Business.Rules.System;

public class PluginBusiness : BusinessAbstract, IPluginBusiness
{
  public PluginBusiness(IRepositories repositories) : base(repositories) { }

  public async Task<DefaultResponseDto<Plugin>> GetByIdAsync(int id, CancellationToken cancellationToken)
      => await new GetPluginByIdQueryHandler(Repositories).HandleAsync(id, cancellationToken);

  public async Task<DefaultResponseDto<IEnumerable<Plugin>>> ListAsync(CancellationToken cancellationToken)
      => await new ListPluginsQueryHandler(Repositories).HandleAsync(0, cancellationToken);

  public async Task<DefaultResponseDto<Plugin>> AddAsync(Plugin plugin, CancellationToken cancellationToken)
      => await new AddPluginCommandHandler(Repositories).HandleAsync(plugin, cancellationToken);

  public async Task<DefaultResponseDto<Plugin>> UpdateAsync(Plugin plugin, CancellationToken cancellationToken)
      => await new UpdatePluginCommandHandler(Repositories).HandleAsync(plugin, cancellationToken);

  public async Task<DefaultResponseDto<bool>> DeleteAsync(int id, CancellationToken cancellationToken)
      => await new DeletePluginCommandHandler(Repositories).HandleAsync(id, cancellationToken);
}
