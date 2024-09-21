using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetAllGatewayParameterQueryHandler : FeatureAbstract<GatewayParameter>, IFeature<DefaultResponseDto<IEnumerable<GatewayParameter>>, int>
{
    public GetAllGatewayParameterQueryHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<IEnumerable<GatewayParameter>>> Handle(int gatewayId, CancellationToken cancellationToken)
    {
        IEnumerable<GatewayParameter> categories = await Repositories
            .GatewayParameter
            .ListAsync(x => x.GatewayId == gatewayId, cancellationToken);

        return DefaultResponseDto<IEnumerable<GatewayParameter>>
            .Create(categories, categories.Count());
    }
}
