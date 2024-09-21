using App.Business.Features.Abstractions;
using App.Domain.Entities.Tools;

namespace App.Business.Features.Tools.Gateways.Validations;

public class GatewayValidate : ValidatorAbstract<Gateway>
{
    public ValidatorAbstract<Gateway> ValidationForAddOrUpdate(Gateway? entity)
    {
        Requires()
            .IsGreaterThan(entity.CategoryId, 0, nameof(Gateway.CategoryId), "Categoria inválida.")
            .AreEquals(entity.Code.Length, 5, nameof(Gateway.Code), "Código inválido.")
            .IsGreaterOrEqualsThan(entity.Title.Length, 10, nameof(Gateway.Title), "Mínimo: 10 caracteres.")
            .IsGreaterOrEqualsThan(entity.Resume.Length, 10, nameof(Gateway.Resume), "Mínimo: 10 caracteres.")

            .IsLowerOrEqualsThan(entity.Title.Length, 100, nameof(Gateway.Title), "Máximo: 100 caracteres.")
            .IsLowerOrEqualsThan(entity.Resume.Length, 200, nameof(Gateway.Resume), "Máximo: 200 caracteres.")
            ;

        return this;
    }

    public ValidatorAbstract<Gateway> ValidationForDelete(Gateway? entity)
    {
        Requires()
            .IsNotNull(entity, nameof(Gateway), "O gateway a ser removido não existe.")
            ;

        return this;
    }
}
