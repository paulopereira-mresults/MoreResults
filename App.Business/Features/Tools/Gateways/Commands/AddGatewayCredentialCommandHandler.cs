using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class AddGatewayCredentialCommandHandler : FeatureAbstract<GatewayCredential>, IFeature<DefaultResponseDto<GatewayCredential>, GatewayCredential>
{
    private readonly GatewayCredentialValidate _validation;

    public AddGatewayCredentialCommandHandler(IRepositories repositories) : base(repositories)
    {
        _validation = new GatewayCredentialValidate();
    }

    public async Task<DefaultResponseDto<GatewayCredential>> Handle(GatewayCredential command, CancellationToken cancellationToken)
    {
        GatewayCredential credential = new GatewayCredential(command.GatewayId, command.Key, command.Value);

        if (_validation.ValidationForAddOrUpdate(credential).IsValid)
        {
            return DefaultResponseDto<GatewayCredential>
                .Create(credential, 0)
                .AddNotifications(_validation.Notifications);
        }

        credential = await Repositories.GatewayCredential.AddAsync(credential, cancellationToken);

        return DefaultResponseDto<GatewayCredential>
                .Create(command, 1);
    }
}
