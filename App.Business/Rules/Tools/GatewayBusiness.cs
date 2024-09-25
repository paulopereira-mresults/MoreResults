using App.Business.Abstractions;
using App.Business.Features.Tools.Gateways.Commands;
using App.Business.Features.Tools.Gateways.Queries;
using App.Domain.Dto;
using App.Domain.Dto.Tools;
using App.Domain.Entities.Tools;
using App.Domain.Enums.Tools;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Business.Rules.Tools;

public class GatewayBusiness : BusinessAbstract, IGatewayBusiness
{
  public GatewayBusiness(IRepositories repositories) : base(repositories) { }

  public async Task<DefaultResponseDto<Gateway>> Add(Gateway gateway, CancellationToken cancellationToken)
      => await new AddGatewayCommandHandler(Repositories).Handle(gateway, cancellationToken);

  public async Task<DefaultResponseDto<Gateway>> Update(Gateway gateway, CancellationToken cancellationToken)
      => await new UpdateGatewayCommandHandler(Repositories).Handle(gateway, cancellationToken);

  public async Task<DefaultResponseDto<IEnumerable<Gateway>>> GetAll(CancellationToken cancellationToken)
      => await new GetAllGatewaysQueryHandler(Repositories).Handle(1, cancellationToken);

  public async Task<DefaultResponseDto<Gateway>> Get(CancellationToken cancellationToken)
      => await new GetGatewayQueryHandler(Repositories).Handle(1, cancellationToken);

  public async Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken)
      => await new DeleteGatewayCommandHandler(Repositories).Handle(id, cancellationToken);

  public async Task<DefaultResponseDto<dynamic>> Execute(HttpMethod method, string code, dynamic parameters, CancellationToken cancellationToken)
  {
    Gateway gateway = await Repositories
        .Gateway
        .GetByCodeAsync(code);

    GatewayRequestExecutionDto request = new GatewayRequestExecutionDto
    {
      Method = method,
      Code = code,
      Parameters = parameters,
      Gateway = gateway
    };

    return gateway.Type switch
    {
      EGatewayType.Database => await new ExecuteDatabaseGatewayCommandHandler(Repositories).Handle(request, cancellationToken),
      _ => throw new NotImplementedException(),
    };
  }
}
