using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Rules.Tools;

public interface IGatewayParameterValidationBusiness : IBusiness
{
    Task<DefaultResponseDto<GatewayValidation>> Add(GatewayValidation validation, CancellationToken cancellationToken);

    Task<DefaultResponseDto<IEnumerable<GatewayValidation>>> GetAllByParameter(int parameterId, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayValidation>> Get(int id, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayValidation>> Update(GatewayValidation category, CancellationToken cancellationToken);
    Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken);
}
