using MoreResults.App.Business.Abstractions;
using MoreResults.App.Business.Features.Tools.Shortlinks.Commands;
using MoreResults.App.Business.Features.Tools.Shortlinks.Queries;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;
using MoreResults.App.IoC.Rules.Tools;

namespace MoreResults.App.Business.Rules.Tools;

public class ShortlinkBusiness : BusinessAbstract, IShortlinkBusiness
{
    public ShortlinkBusiness(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<IEnumerable<Shortlink>>> List(CancellationToken cancellationToken)
        => await new ListShortlinksQueryHandler(Repositories).Handle(0, cancellationToken);

    public async Task<DefaultResponseDto<Shortlink>> GetByCodeAsync(string code, CancellationToken cancellationToken)
        => await new GetShortlinkByCodeQueryHandler(Repositories).Handle(code, cancellationToken);

    public async Task<DefaultResponseDto<Shortlink>> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await new GetShortlinkByIdQueryHandler(Repositories).Handle(id, cancellationToken);

    public async Task<DefaultResponseDto<Shortlink>?> AddAsync(Shortlink shortlink, CancellationToken cancellationToken)
        => await new AddShortlinkCommandHandler(Repositories).Handle(shortlink, cancellationToken);

    public async Task<DefaultResponseDto<Shortlink>?> UpdateAsync(Shortlink shortlink, CancellationToken cancellationToken)
        => await new UpdateShortlinkCommandHandler(Repositories).Handle(shortlink, cancellationToken);

    public async Task<DefaultResponseDto<bool>?> DeleteAsync(int id, CancellationToken cancellationToken)
        => await new DeleteShortlinkCommandHandler(Repositories).Handle(id, cancellationToken);

}
