using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;

namespace App.Business.Features.Tools.Gateways.Queries;

public class GetGatewayCredentialQueryHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<GatewayCredential>, int>
{
    public GetGatewayCredentialQueryHandler(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<DefaultResponseDto<GatewayCredential>> Handle(int command, CancellationToken cancellationToken)
    {
        GatewayCredential? credential = await Repositories
            .GatewayCredential
            .GetByIdAsync(command, cancellationToken);

        return DefaultResponseDto<GatewayCredential>
            .Create(credential);
    }
}
