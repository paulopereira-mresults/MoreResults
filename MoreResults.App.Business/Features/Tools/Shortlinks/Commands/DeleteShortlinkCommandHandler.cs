using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Business.Features.Tools.Shortlinks.Validators;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Commands;

public class DeleteShortlinkCommandHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<bool>, int>
{
    private readonly ShortlinkValidator _validator;

    public DeleteShortlinkCommandHandler(IRepositories repositories) : base(repositories)
    {
        _validator = new ShortlinkValidator();
    }

    public async Task<DefaultResponseDto<bool>> Handle(int command, CancellationToken cancellationToken)
    {
        Shortlink? shortlink = await Repositories
            .Shortlink
            .GetByIdAsync(command, cancellationToken);

        bool isDeleted = false;

        if (_validator.ValidationForDelete(shortlink).IsValid)
        {
            isDeleted = await Repositories
                .Shortlink
                .DeleteAsync(shortlink, cancellationToken);
        }

        return DefaultResponseDto<bool>
            .Create(isDeleted)
            .AddNotifications(_validator.Notifications);
    }
}
