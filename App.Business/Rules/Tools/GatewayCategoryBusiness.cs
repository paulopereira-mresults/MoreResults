using App.Business.Abstractions;
using App.Business.Features.Tools.Gateway.Commands;
using App.Business.Features.Tools.Gateway.Queries;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using App.IoC.Rules.Tools;

namespace App.Business.Rules.Tools;

public class GatewayCategoryBusiness : BusinessAbstract, IGatewayCategoryBusiness
{
    public GatewayCategoryBusiness(IRepositories repositories) : base(repositories)
    {
    }

    public async Task<DefaultResponseDto<IEnumerable<GatewayCategory>>> GetAll(CancellationToken cancellationToken)
    => await new GetAllCategoriesQueryHandler(Repositories).Handle(1, cancellationToken);

    public async Task<DefaultResponseDto<GatewayCategory>> Get(CancellationToken cancellationToken)
    => await new GetCategoryQueryHandler(Repositories).Handle(1, cancellationToken);

    public async Task<DefaultResponseDto<GatewayCategory>> Add(GatewayCategory category, CancellationToken cancellationToken)
    => await new AddCategoryCommandHandler(Repositories).Handle(category, cancellationToken);

    public async Task<DefaultResponseDto<GatewayCategory>> Update(GatewayCategory category, CancellationToken cancellationToken)
    => await new UpdateCategoryCommandHandler(Repositories).Handle(category, cancellationToken);

    public async Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken)
    => await new DeleteCategoryCommandHandler(Repositories).Handle(id, cancellationToken);


}
