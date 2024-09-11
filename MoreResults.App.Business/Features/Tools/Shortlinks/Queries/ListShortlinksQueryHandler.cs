using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Queries;

public class ListShortlinksQueryHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<IEnumerable<Shortlink>>, int>
{
    public ListShortlinksQueryHandler(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<DefaultResponseDto<IEnumerable<Shortlink>>> Handle(int command, CancellationToken cancellationToken)
    {
        IEnumerable<Shortlink> shorlinks = await Repositories.Shortlink.ListAsync(cancellationToken);

        DefaultResponseDto<IEnumerable<Shortlink>> response = DefaultResponseDto<IEnumerable<Shortlink>>
            .Create(shorlinks, shorlinks.Count());

        return response;
    }
}
