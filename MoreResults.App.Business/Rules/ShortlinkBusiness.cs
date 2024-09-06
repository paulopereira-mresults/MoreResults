using MoreResults.App.Business.Abstractions;
using MoreResults.App.Domain.Entities.Tools;
using MoreResults.App.IoC;
using MoreResults.App.IoC.Rules.Tools;

namespace MoreResults.App.Business.Rules;

public class ShortlinkBusiness : BusinessAbstract, IShortlinkBusiness
{
    public ShortlinkBusiness(IRepositories repositories) : base(repositories) { }

    public async Task<Shortlink?> GetByCodeAsync(string code)
        => await Repositories.Shortlink.GetByCodeAsync(code);
    
}
