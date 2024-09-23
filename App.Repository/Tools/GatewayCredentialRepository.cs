using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class GatewayCredentialRepository : RepositoryAbstract<GatewayCredential>, IGatewayCredentialRepository
{
    public GatewayCredentialRepository(DefaultContext context) : base(context)
    {
    }
}
