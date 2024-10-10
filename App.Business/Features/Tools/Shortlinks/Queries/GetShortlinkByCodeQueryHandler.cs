using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Shortlinks.Commands;
using App.Business.Features.Tools.Shortlinks.Validators;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Shortlinks.Queries;

public class GetShortlinkByCodeQueryHandler : FeatureAbstract<Shortlink>, IFeature<DefaultResponseDto<Shortlink>, string>
{
  private readonly ShortlinkValidator _validator;

  public GetShortlinkByCodeQueryHandler(IRepositories repositories) : base(repositories)
  {
    _validator = new ShortlinkValidator();
  }

  public async Task<DefaultResponseDto<Shortlink>> HandleAsync(string command, CancellationToken cancellationToken)
  {
    Shortlink? shortlink = await Repositories.Shortlink.GetByCodeAsync(command, cancellationToken);

    if (_validator.ValidationForGet(shortlink).IsValid)
      await new AddOneVisitorOnShortlinkCommandHandler(Repositories).HandleAsync(shortlink, cancellationToken);
    
    return DefaultResponseDto<Shortlink>
      .Create(shortlink)
      .AddNotifications(_validator.Notifications);
  }
}
