using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateways.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Commands;

public class UpdateCategoryCommandHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<GatewayCategory>, GatewayCategory>
{
    private readonly GatewayCategoryValidate _validation;

    public UpdateCategoryCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayCategoryValidate();
    }

    public async Task<DefaultResponseDto<GatewayCategory>> Handle(GatewayCategory command, CancellationToken cancellationToken)
    {
        GatewayCategory? category = await Repositories.GatewayCategory.GetByIdAsync(command.Id, cancellationToken);

        category?.Update(command.Name, command.Description);

        if (_validation.ValidationForAddOrUpdate(category).IsValid)
        {
            return DefaultResponseDto<GatewayCategory>
                .Create(command, 0)
                .AddNotifications(_validation.Notifications);
        }

        category = await Repositories.GatewayCategory.UpdateAsync(category, cancellationToken);

        return DefaultResponseDto<GatewayCategory>
                .Create(command, 1);
    }
}
