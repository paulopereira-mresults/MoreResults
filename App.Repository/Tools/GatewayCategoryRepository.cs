using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class GatewayCategoryRepository : RepositoryAbstract<GatewayCategory>, IGatewayCategoryRepository
{
    public GatewayCategoryRepository(DefaultContext context) : base(context)
    {
    }

}
