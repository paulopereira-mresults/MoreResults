using MoreResults.App.Business.Features.Abstractions;
using MoreResults.App.Business.Interfaces;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;

namespace MoreResults.App.Business.Features.Tools.Shortlinks.Commands;

/// <summary>
/// Adiciona um link encurtado
/// </summary>
public class AddShortlinkCommand: FeatureAbstract<Shortlink>, IFeature<Shortlink, AddShortlinkRequest>
{
    public AddShortlinkCommand(IRepositories repositories, IValidatable<Shortlink> validation): base(repositories, validation) { }

    public async Task<Shortlink> Handle(AddShortlinkRequest request)
    {
        Shortlink? shortlink = new(request.Link, request.Resume);

        Validation.Validate(shortlink);

        return await Repositories.Shortlink.Add(shortlink);
    }

}
