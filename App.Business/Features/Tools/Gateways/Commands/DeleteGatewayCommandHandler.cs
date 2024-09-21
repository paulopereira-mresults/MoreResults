using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class DeleteGatewayCommandHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<bool>, int>
{
    private readonly GatewayValidate _validation;

    public DeleteGatewayCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayValidate();
    }

    public async Task<DefaultResponseDto<bool>> Handle(int command, CancellationToken cancellationToken)
    {
        Gateway? category = await Repositories.Gateway.GetByIdAsync(command, cancellationToken);

        if (_validation.ValidationForDelete(category).IsValid)
        {
            return DefaultResponseDto<bool>
                .Create(false, 0)
                .AddNotifications(_validation.Notifications);
        }

        bool isDeleted = await Repositories.Gateway.DeleteAsync(category, cancellationToken);

        return DefaultResponseDto<bool>
                .Create(isDeleted, 1);
    }
}
