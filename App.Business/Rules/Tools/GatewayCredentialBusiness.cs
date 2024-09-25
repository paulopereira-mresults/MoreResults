using App.Business.Abstractions;
using App.Business.Features.Tools.Gateways.Commands;
using App.Business.Features.Tools.Gateways.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Business.Rules.Tools;

public class GatewayCredentialBusiness : BusinessAbstract, IGatewayCredentialBusiness
{
  public GatewayCredentialBusiness(IRepositories repositories) : base(repositories) { }

  public async Task<DefaultResponseDto<GatewayCredential>> Add(GatewayCredential credential, CancellationToken cancellationToken)
      => await new AddGatewayCredentialCommandHandler(Repositories).Handle(credential, cancellationToken);

  public async Task<DefaultResponseDto<GatewayCredential>> Update(GatewayCredential credential, CancellationToken cancellationToken)
      => await new UpdateGatewayCredentialCommandHandler(Repositories).Handle(credential, cancellationToken);

  public async Task<DefaultResponseDto<IEnumerable<GatewayCredential>>> GetAll(int credentialId, CancellationToken cancellationToken)
      => await new GetAllGatewayCredentialsQueryHandler(Repositories).Handle(credentialId, cancellationToken);

  public async Task<DefaultResponseDto<GatewayCredential>> Get(CancellationToken cancellationToken)
      => await new GetGatewayCredentialQueryHandler(Repositories).Handle(1, cancellationToken);

  public async Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken)
      => await new DeleteGatewayCredentialCommandHandler(Repositories).Handle(id, cancellationToken);
}
