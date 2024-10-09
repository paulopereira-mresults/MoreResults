using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Shortlinks.Validators;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Shortlinks.Commands;

/// <summary>
/// Adiciona um link encurtado
/// </summary>
public class AddShortlinkCommandHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, Shortlink>
{
  private readonly ShortlinkValidator _validator;

  public AddShortlinkCommandHandler(IRepositories repositories) : base(repositories)
  {
    _validator = new ShortlinkValidator();
  }

  public async Task<DefaultResponseDto<Shortlink>> Handle(Shortlink request, CancellationToken cancellationToken)
  {
    Shortlink? shortlink = new(request.Link, request.Resume);

    _validator.ValidationForAddOrUpdate(shortlink);

    if (_validator.IsValid)
      shortlink = await Repositories.Shortlink.AddAsync(shortlink, cancellationToken);

    return DefaultResponseDto<Shortlink>
        .Create(shortlink)
        .AddNotifications(_validator.Notifications);
  }

}
