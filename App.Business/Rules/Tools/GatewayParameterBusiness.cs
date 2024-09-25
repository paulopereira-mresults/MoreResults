using App.Business.Abstractions;
using App.Business.Features.Tools.Gateways.Commands;
using App.Business.Features.Tools.Gateways.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Business.Rules.Tools;

public class GatewayParameterBusiness : BusinessAbstract, IGatewayParameterBusiness
{
  public GatewayParameterBusiness(IRepositories repositories) : base(repositories) { }

  public async Task<DefaultResponseDto<IEnumerable<GatewayParameter>>> ListAllByGateway(int gatewayId, CancellationToken cancellationToken)
      => await new GetAllGatewayParameterQueryHandler(Repositories).Handle(gatewayId, cancellationToken);

  public async Task<DefaultResponseDto<GatewayParameter>> GetById(int parameterId, CancellationToken cancellationToken)
      => await new GetGatewayParameterQueryHandler(Repositories).Handle(parameterId, cancellationToken);

  public async Task<DefaultResponseDto<GatewayParameter>> Add(GatewayParameter parameter, CancellationToken cancellationToken)
      => await new AddGatewayParameterCommandHandler(Repositories).Handle(parameter, cancellationToken);

  public async Task<DefaultResponseDto<GatewayParameter>> Update(GatewayParameter parameter, CancellationToken cancellationToken)
      => await new UpdateGatewayParameterCommandHandler(Repositories).Handle(parameter, cancellationToken);

  public async Task<DefaultResponseDto<bool>> Delete(int parameterId, CancellationToken cancellationToken)
      => await new DeleteGatewayParameterCommandHandler(Repositories).Handle(parameterId, cancellationToken);
}
