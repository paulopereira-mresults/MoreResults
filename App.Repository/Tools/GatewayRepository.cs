using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class GatewayRepository : RepositoryAbstract<Gateway>, IGatewayRepository
{
    public GatewayRepository(DefaultContext context) : base(context)
    {
    }

}
