using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class GatewayParameterRepository : RepositoryAbstract<GatewayParameter>, IGatewayParameterRepository
{
    public GatewayParameterRepository(DefaultContext context) : base(context)
    {
    }

}
