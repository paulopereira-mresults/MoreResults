using App.Business.Features.Abstractions;
using App.Business.Features.Tools.Gateway.Validations;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateway.Commands;

public class DeleteCategoryCommandHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<bool>, int>
{
    private readonly GatewayCategoryValidation _validation;

    public DeleteCategoryCommandHandler(IRepositories repositories) : base(repositories)
    { 
        _validation = new GatewayCategoryValidation();
    }

    public async Task<DefaultResponseDto<bool>> Handle(int command, CancellationToken cancellationToken)
    {
        GatewayCategory? category = await Repositories.GatewayCategory.GetByIdAsync(command, cancellationToken);

        if (_validation.ValidationForDelete(category).IsValid)
        {
            return DefaultResponseDto<bool>
                .Create(false, 0)
                .AddNotifications(_validation.Notifications);
        }

        bool isDeleted = await Repositories.GatewayCategory.DeleteAsync(category, cancellationToken);

        return DefaultResponseDto<bool>
                .Create(isDeleted, 1);
    }
}
