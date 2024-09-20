using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetGatewayQueryHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<Gateway>, int>
{
    public GetGatewayQueryHandler(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<DefaultResponseDto<Gateway>> Handle(int command, CancellationToken cancellationToken)
    {
        Gateway? category = await Repositories
            .Gateway
            .GetByIdAsync(command, cancellationToken);

        return DefaultResponseDto<Gateway>
            .Create(category);
    }
}
