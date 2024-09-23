using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetAllGatewayCredentialsQueryHandler : FeatureAbstract<GatewayCredential>, IFeature<DefaultResponseDto<IEnumerable<GatewayCredential>>, int>
{
    public GetAllGatewayCredentialsQueryHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<IEnumerable<GatewayCredential>>> Handle(int command, CancellationToken cancellationToken)
    {
        IEnumerable<GatewayCredential> credentials = await Repositories
            .GatewayCredential
            .ListAsync(cancellationToken);

        return DefaultResponseDto<IEnumerable<GatewayCredential>>
            .Create(credentials, credentials.Count());
    }
}
