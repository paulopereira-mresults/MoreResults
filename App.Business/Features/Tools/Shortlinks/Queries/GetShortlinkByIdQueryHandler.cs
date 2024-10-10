using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Shortlinks.Commands;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Shortlinks.Queries;

public class GetShortlinkByIdQueryHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, int>
{
  public GetShortlinkByIdQueryHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<Shortlink>> HandleAsync(int command, CancellationToken cancellationToken)
  {
    Shortlink? shortlink = await Repositories.Shortlink.GetByIdAsync(command, cancellationToken);

    if (shortlink is not null)
      await new AddOneVisitorOnShortlinkCommandHandler(Repositories).HandleAsync(shortlink, cancellationToken);

    return DefaultResponseDto<Shortlink>.Create(shortlink);
  }
}
