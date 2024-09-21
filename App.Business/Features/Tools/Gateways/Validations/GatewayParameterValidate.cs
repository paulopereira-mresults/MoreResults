using App.Business.Features.Abstractions;
using App.Domain.Entities.Tools;

namespace App.Business.Features.Tools.Gateways.Validations;

public class GatewayParameterValidate : ValidatorAbstract<GatewayParameter>
{
    public ValidatorAbstract<GatewayParameter> ValidationForAddOrUpdate(GatewayParameter? entity)
    {
        if (entity is null)
        {
            AddNotification(nameof(GatewayParameter), "Parâmetro inválido.");
        }

        Requires()
            ;

        return this;
    }

    public ValidatorAbstract<GatewayParameter> ValidationForDelete(GatewayParameter? entity)
    {
        Requires()
            .IsNotNull(entity, nameof(Gateway), "O parâmetro a ser removido não existe.")
            ;

        return this;
    }
}
