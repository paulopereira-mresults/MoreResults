using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Rules.Tools;

public interface IGatewayParameterBusiness: IBusiness
{
    Task<DefaultResponseDto<IEnumerable<GatewayParameter>>> ListAllByGateway(int gatewayId, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayParameter>> GetById(int parameterId, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayParameter>> Add(GatewayParameter parameter, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayParameter>> Update(GatewayParameter parameter, CancellationToken cancellationToken);
    Task<DefaultResponseDto<bool>> Delete(int parameterId, CancellationToken cancellationToken);
}
