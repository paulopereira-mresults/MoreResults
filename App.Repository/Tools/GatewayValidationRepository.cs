using App.Domain.Entities.Tools;
using App.Infrastructure.Contexts;
using App.IoC.Repositories.Tools;
using App.Repository.Abstractions;

namespace App.Repository.Tools;

public class GatewayValidationRepository : RepositoryAbstract<GatewayValidation>, IGatewayValidationRepository
{
    public GatewayValidationRepository(DefaultContext context) : base(context)
    {
    }

}
