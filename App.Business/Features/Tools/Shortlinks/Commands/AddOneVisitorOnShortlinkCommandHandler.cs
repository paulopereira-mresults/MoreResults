using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Shortlinks.Commands;

public class AddOneVisitorOnShortlinkCommandHandler : FeatureAbstract<ShortlinkAccess>, IFeature<bool, Shortlink>
{
    public AddOneVisitorOnShortlinkCommandHandler(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<bool> Handle(Shortlink command, CancellationToken cancellationToken)
    {
        ShortlinkAccess access = new ShortlinkAccess(command.Id, string.Empty);
        access = await Repositories.ShortlinkAccess.AddAsync(access, cancellationToken);

        return access.Id > 0;
    }

}
