using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Rules.Tools;

public interface IGatewayCredentialBusiness : IBusiness
{
    Task<DefaultResponseDto<GatewayCredential>> Add(GatewayCredential credential, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayCredential>> Update(GatewayCredential credential, CancellationToken cancellationToken);
    Task<DefaultResponseDto<IEnumerable<GatewayCredential>>> GetAll(int credentialId, CancellationToken cancellationToken);
    Task<DefaultResponseDto<GatewayCredential>> Get(CancellationToken cancellationToken);
    Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken);
}
