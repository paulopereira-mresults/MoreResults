using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetGatewayParameterQueryHandler : FeatureAbstract<GatewayParameter>, IFeature<DefaultResponseDto<GatewayParameter>, int>
{
    public GetGatewayParameterQueryHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<GatewayParameter>> Handle(int parameterId, CancellationToken cancellationToken)
    {
        GatewayParameter? categories = await Repositories
            .GatewayParameter
            .GetByIdAsync(parameterId, cancellationToken);

        return DefaultResponseDto<GatewayParameter>
            .Create(categories);
    }
}
