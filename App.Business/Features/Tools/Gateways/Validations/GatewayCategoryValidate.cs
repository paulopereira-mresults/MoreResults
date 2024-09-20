using App.Business.Features.Abstractions;
using App.Domain.Entities.Tools;

namespace App.Business.Features.Tools.Gateways.Validations;

public class GatewayCategoryValidate: ValidatorAbstract<GatewayCategory>
{
    public ValidatorAbstract<GatewayCategory> ValidationForAddOrUpdate(GatewayCategory? entity)
    {
        if (entity is null)
        {
            AddNotification(nameof(GatewayCategory), "Categoria inválida.");
            return this;
        }

        Requires()
            .IsGreaterOrEqualsThan(entity.Name, 10, nameof(entity.Name),  "Mínimo: 10 caracteres")
            .IsGreaterOrEqualsThan(entity.Description, 10, nameof(entity.Description),  "Minimo: 10 caracteres")

            .IsLowerOrEqualsThan(entity.Name, 100, nameof(entity.Name), "Máximo: 100 caracteres")
            .IsLowerOrEqualsThan(entity.Description, 100, nameof(entity.Description), "Máximo: 100 caracteres")
            ;

        return this;
    }

    public ValidatorAbstract<GatewayCategory> ValidationForDelete(GatewayCategory? entity)
    {
        Requires()
            .IsNull(entity, nameof(GatewayCategory), "A categoria a ser apagada não existe.")
            ;

        return this;
    }
}
