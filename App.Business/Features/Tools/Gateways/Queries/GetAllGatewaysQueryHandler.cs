using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetAllGatewaysQueryHandler : FeatureAbstract<Gateway>, IFeature<DefaultResponseDto<IEnumerable<Gateway>>, int>
{
    public GetAllGatewaysQueryHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<IEnumerable<Gateway>>> Handle(int command, CancellationToken cancellationToken)
    {
        IEnumerable<Gateway> gateways = await Repositories
            .Gateway
            .ListAsync(cancellationToken);

        return DefaultResponseDto<IEnumerable<Gateway>>
            .Create(gateways, gateways.Count());
    }
}
