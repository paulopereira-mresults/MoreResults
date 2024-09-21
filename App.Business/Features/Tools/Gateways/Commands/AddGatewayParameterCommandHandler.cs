using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class AddGatewayParameterCommandHandler : FeatureAbstract<GatewayParameter>, IFeature<DefaultResponseDto<GatewayParameter>, GatewayParameter>
{
    private readonly GatewayParameterValidate _validation;

    public AddGatewayParameterCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayParameterValidate();
    }

    public async Task<DefaultResponseDto<GatewayParameter>> Handle(GatewayParameter command, CancellationToken cancellationToken)
    {
        GatewayParameter parameter = new GatewayParameter(command.GatewayId, command.IsRequired, command.Type, command.Name, command.Resume, command.Value);

        if (_validation.ValidationForAddOrUpdate(parameter).IsValid)
        {
            return DefaultResponseDto<GatewayParameter>
                .Create(command, 0)
                .AddNotifications(_validation.Notifications);
        }

        parameter = await Repositories.GatewayParameter.AddAsync(parameter, cancellationToken);

        return DefaultResponseDto<GatewayParameter>
                .Create(command, 1);
    }
}
