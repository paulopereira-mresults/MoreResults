using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Commands;

/// <summary>
/// Adiciona um link encurtado
/// </summary>
public class AddShortlinkCommandHandler: FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, Shortlink>
{
    private readonly ShortlinkValidator _validator;

    public AddShortlinkCommandHandler(IRepositories repositories): base(repositories)
    {
         _validator = new ShortlinkValidator();
    }

    public async Task<DefaultResponseDto<Shortlink>> Handle(Shortlink request)
    {
        Shortlink? shortlink = new(request.Link, request.Resume);

        _validator.Validate(shortlink);

        if (_validator.IsValid)
            shortlink = await Repositories.Shortlink.AddAsync(request);

        return DefaultResponseDto<Shortlink>
            .Create(shortlink)
            .AddNotifications(_validator.Notifications);
    }

}
