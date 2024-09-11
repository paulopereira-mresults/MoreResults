using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Business.Features.Tools.Shortlinks.Commands;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Queries;

public class GetShortlinkByIdQueryHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, int>
{
    public GetShortlinkByIdQueryHandler(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<DefaultResponseDto<Shortlink>> Handle(int command, CancellationToken cancellationToken)
    {
        Shortlink? shortlink = await Repositories.Shortlink.GetByIdAsync(command, cancellationToken);

        if (shortlink is not null)
            await new AddOneVisitorOnShortlinkCommandHandler(Repositories).Handle(shortlink, cancellationToken);

        return DefaultResponseDto<Shortlink>.Create(shortlink);
    }
}
