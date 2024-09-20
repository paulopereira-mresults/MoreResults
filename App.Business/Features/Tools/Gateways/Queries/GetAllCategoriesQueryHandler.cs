using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetAllCategoriesQueryHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<IEnumerable<GatewayCategory>>, int>
{
    public GetAllCategoriesQueryHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<IEnumerable<GatewayCategory>>> Handle(int command, CancellationToken cancellationToken)
    {
        IEnumerable<GatewayCategory> categories = await Repositories
            .GatewayCategory
            .ListAsync(cancellationToken);

        return DefaultResponseDto<IEnumerable<GatewayCategory>>
            .Create(categories, categories.Count());
    }
}
