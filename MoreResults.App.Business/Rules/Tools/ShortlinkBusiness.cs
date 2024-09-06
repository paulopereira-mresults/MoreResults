using MoreResults.App.Business.Abstractions;
using MoreResults.App.Business.Features.Tools.Shortlinks.Commands;
using MoreResults.App.Domain.Dto;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;
using MoreResults.App.IoC.Rules.Tools;

namespace MoreResults.App.Business.Rules.Tools;

public class ShortlinkBusiness : BusinessAbstract, IShortlinkBusiness
{
    public ShortlinkBusiness(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<Shortlink>> GetByCodeAsync(string code)
    {
        Shortlink? shortlink = await Repositories.Shortlink.GetByCodeAsync(code);
        return DefaultResponseDto<Shortlink>.Create(shortlink);
    }

    public async Task<DefaultResponseDto<Shortlink>> GetByIdAsync(int id)
    {
        Shortlink? shortlink = await Repositories.Shortlink.GetByIdAsync(id);
        return DefaultResponseDto<Shortlink>.Create(shortlink);
    }

    public async Task<DefaultResponseDto<Shortlink>?> AddAsync(Shortlink shortlink)
        => await new AddShortlinkCommandHandler(Repositories).Handle(shortlink);

    public async Task<DefaultResponseDto<Shortlink>?> UpdateAsync(Shortlink shortlink)
        => await new UpdateShortlinkCommandHandler(Repositories).Handle(shortlink);

}
