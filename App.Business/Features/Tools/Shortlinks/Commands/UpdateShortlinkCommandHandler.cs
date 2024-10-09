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
public class UpdateShortlinkCommandHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, Shortlink>
{
  private readonly ShortlinkValidator _validator;

  public UpdateShortlinkCommandHandler(IRepositories repositories) : base(repositories)
  {
    _validator = new ShortlinkValidator();
  }

  public async Task<DefaultResponseDto<Shortlink>> Handle(Shortlink request, CancellationToken cancellationToken)
  {
    Shortlink? shortlink = await Repositories.Shortlink.GetByIdAsync(request.Id, cancellationToken);
    shortlink.Update(request.Link, request.Resume);

    if (_validator.ValidationForAddOrUpdate(shortlink).IsValid)
      shortlink = await Repositories.Shortlink.UpdateAsync(request, cancellationToken);

    return DefaultResponseDto<Shortlink>
        .Create(shortlink)
        .AddNotifications(_validator.Notifications);
  }

}
