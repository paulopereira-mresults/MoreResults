using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class UpdateGatewayCommandHandler : FeatureAbstract<Gateway>, IFeature<DefaultResponseDto<Gateway>, Gateway>
{
    private readonly GatewayValidate _validation;

    public UpdateGatewayCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayValidate();
    }

    public async Task<DefaultResponseDto<Gateway>> Handle(Gateway command, CancellationToken cancellationToken)
    {
        Gateway? gateway = await Repositories.Gateway.GetByIdAsync(command.Id, cancellationToken);

        gateway?.Update(command.CategoryId, command.IsActive, command.Title, command.Resume, command.Type);

        if (_validation.ValidationForAddOrUpdate(gateway).IsValid)
        {
            return DefaultResponseDto<Gateway>
                .Create(command, 0)
                .AddNotifications(_validation.Notifications);
        }

        gateway = await Repositories.Gateway.UpdateAsync(gateway, cancellationToken);

        return DefaultResponseDto<Gateway>
                .Create(command, 1);
    }
}
