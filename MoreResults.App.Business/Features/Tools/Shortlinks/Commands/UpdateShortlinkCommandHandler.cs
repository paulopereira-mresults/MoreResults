using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Commands;

/// <summary>
/// Adiciona um link encurtado
/// </summary>
public class UpdateShortlinkCommandHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, Shortlink>
{
    private readonly ShortlinkValidator _validator;

    public UpdateShortlinkCommandHandler(IRepositories repositories): base(repositories)
    {
         _validator = new ShortlinkValidator();
    }

    public async Task<DefaultResponseDto<Shortlink>> Handle(Shortlink request)
    {
        Shortlink? shortlink = await Repositories.Shortlink.GetByIdAsync(request.Id);
        shortlink.Update(request.Link, request.Resume);

        if (_validator.Validate(shortlink).IsValid)
            shortlink = await Repositories.Shortlink.UpdateAsync(request);

        return DefaultResponseDto<Shortlink>
            .Create(shortlink)
            .AddNotifications(_validator.Notifications);
    }

}
