using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateway.Queries;

public class GetCategoryQueryHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<GatewayCategory>, int>
{
    public GetCategoryQueryHandler(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<DefaultResponseDto<GatewayCategory>> Handle(int command, CancellationToken cancellationToken)
    {
        GatewayCategory? category = await Repositories
            .GatewayCategory
            .GetByIdAsync(command, cancellationToken);

        return DefaultResponseDto<GatewayCategory>
            .Create(category);
    }
}
