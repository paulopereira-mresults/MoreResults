using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Shortlinks.Queries;

public class ListShortlinksQueryHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<IEnumerable<Shortlink>>, int>
{
  public ListShortlinksQueryHandler(IRepositories repositories) : base(repositories)
  {
  }

  public async Task<DefaultResponseDto<IEnumerable<Shortlink>>> HandleAsync(int command, CancellationToken cancellationToken)
  {
    IEnumerable<Shortlink> shorlinks = await Repositories.Shortlink.ListAsync(cancellationToken);

    DefaultResponseDto<IEnumerable<Shortlink>> response = DefaultResponseDto<IEnumerable<Shortlink>>
        .Create(shorlinks, shorlinks.Count());

    return response;
  }
}
