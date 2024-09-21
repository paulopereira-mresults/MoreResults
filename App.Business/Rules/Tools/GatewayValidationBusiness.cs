using App.Business.Abstractions;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Business.Rules.Tools;

public class GatewayParameterValidationBusiness : BusinessAbstract, IGatewayParameterValidationBusiness
{
    public GatewayParameterValidationBusiness(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<IEnumerable<GatewayValidation>>> GetAllByParameter(int parameterId, CancellationToken cancellationToken)
        => await new GetAllGatewayParameterValidationQueryHandler(Repositories).Handle(parameterId, cancellationToken);

    public async Task<DefaultResponseDto<GatewayValidation>> Get(int parameterId, CancellationToken cancellationToken)
        => await new GetGatewayParameterValidationQueryHandler(Repositories).Handle(validationId, cancellationToken);

    public async Task<DefaultResponseDto<GatewayValidation>> Add(GatewayValidation validation, CancellationToken cancellationToken)
        => await new AddGatewayParameterValidationCommandHandler(Repositories).Handle(validation, cancellationToken);

    public async Task<DefaultResponseDto<GatewayValidation>> Update(GatewayValidation validation, CancellationToken cancellationToken)
        => await new UpdateGatewayParameterValiationCommandHandler(Repositories).Handle(validation, cancellationToken);

    public async Task<DefaultResponseDto<bool>> Delete(int validationId, CancellationToken cancellationToken)
        => await new DeleteGatewayParameterValidationCommandHandler(Repositories).Handle(validationId, cancellationToken);
}
