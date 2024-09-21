using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class DeleteGatewayParameterCommandHandler : FeatureAbstract<GatewayParameter>, IFeature<DefaultResponseDto<bool>, int>
{
    private readonly GatewayParameterValidate _validation;

    public DeleteGatewayParameterCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayParameterValidate();
    }

    public async Task<DefaultResponseDto<bool>> Handle(int command, CancellationToken cancellationToken)
    {
        GatewayParameter? parameter = await Repositories.GatewayParameter.GetByIdAsync(command, cancellationToken);

        if (_validation.ValidationForDelete(parameter).IsValid)
        {
            return DefaultResponseDto<bool>
                .Create(false, 0)
                .AddNotifications(_validation.Notifications);
        }

        bool isDeleted = await Repositories.GatewayParameter.DeleteAsync(parameter, cancellationToken);

        return DefaultResponseDto<bool>
                .Create(isDeleted, 1);
    }
}
