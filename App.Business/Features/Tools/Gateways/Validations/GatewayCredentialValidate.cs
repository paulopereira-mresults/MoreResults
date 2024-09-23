using App.Business.Features.Abstractions;
using App.Domain.Entities.Tools;

namespace App.Business.Features.Tools.Gateways.Validations;

public class GatewayCredentialValidate : ValidatorAbstract<GatewayCredential>
{
    public ValidatorAbstract<GatewayCredential> ValidationForAddOrUpdate(GatewayCredential? entity)
    {
        Requires()
            ;

        return this;
    }

    public ValidatorAbstract<GatewayCredential> ValidationForDelete(GatewayCredential? entity)
    {
        Requires()
            ;

        return this;
    }
}
