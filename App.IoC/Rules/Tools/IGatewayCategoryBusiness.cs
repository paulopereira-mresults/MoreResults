using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Rules.Tools;

public interface IGatewayCategoryBusiness : IBusiness
{
    Task<DefaultResponseDto<IEnumerable<GatewayCategory>>> GetAll(CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayCategory>> Get(CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayCategory>> Add(GatewayCategory category, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayCategory>> Update(GatewayCategory category, CancellationToken cancellationToken);
    Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken);
}
