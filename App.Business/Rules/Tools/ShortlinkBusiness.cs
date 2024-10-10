using App.Business.Abstractions;
using App.Business.Features.Tools.Shortlinks.Commands;
using App.Business.Features.Tools.Shortlinks.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Business.Rules.Tools;

public class ShortlinkBusiness : BusinessAbstract, IShortlinkBusiness
{
  public ShortlinkBusiness(IRepositories repositories) : base(repositories) { }

  public async Task<DefaultResponseDto<IEnumerable<Shortlink>>> List(CancellationToken cancellationToken)
      => await new ListShortlinksQueryHandler(Repositories).HandleAsync(0, cancellationToken);

  public async Task<DefaultResponseDto<Shortlink>> GetByCodeAsync(string code, CancellationToken cancellationToken)
      => await new GetShortlinkByCodeQueryHandler(Repositories).HandleAsync(code, cancellationToken);

  public async Task<DefaultResponseDto<Shortlink>> GetByIdAsync(int id, CancellationToken cancellationToken)
      => await new GetShortlinkByIdQueryHandler(Repositories).HandleAsync(id, cancellationToken);

  public async Task<DefaultResponseDto<Shortlink>?> AddAsync(Shortlink shortlink, CancellationToken cancellationToken)
      => await new AddShortlinkCommandHandler(Repositories).HandleAsync(shortlink, cancellationToken);

  public async Task<DefaultResponseDto<Shortlink>?> UpdateAsync(Shortlink shortlink, CancellationToken cancellationToken)
      => await new UpdateShortlinkCommandHandler(Repositories).HandleAsync(shortlink, cancellationToken);

  public async Task<DefaultResponseDto<bool>?> DeleteAsync(int id, CancellationToken cancellationToken)
      => await new DeleteShortlinkCommandHandler(Repositories).HandleAsync(id, cancellationToken);

}
