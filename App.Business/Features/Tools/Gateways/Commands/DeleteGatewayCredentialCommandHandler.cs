using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class DeleteGatewayCredentialCommandHandler : FeatureAbstract<GatewayCredential>, IFeature<DefaultResponseDto<bool>, int>
{
    private readonly GatewayCredentialValidate _validation;

    public DeleteGatewayCredentialCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayCredentialValidate();
    }

    public async Task<DefaultResponseDto<bool>> Handle(int command, CancellationToken cancellationToken)
    {
        GatewayCredential? category = await Repositories.GatewayCredential.GetByIdAsync(command, cancellationToken);

        if (_validation.ValidationForDelete(category).IsValid)
        {
            return DefaultResponseDto<bool>
                .Create(false, 0)
                .AddNotifications(_validation.Notifications);
        }

        bool isDeleted = await Repositories.GatewayCredential.DeleteAsync(category, cancellationToken);

        return DefaultResponseDto<bool>
                .Create(isDeleted, 1);
    }
}
