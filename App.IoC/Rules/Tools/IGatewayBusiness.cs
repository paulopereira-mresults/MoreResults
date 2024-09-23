using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Rules.Tools;

public interface IGatewayBusiness : IBusiness
{
    Task<DefaultResponseDto<Gateway>> Add(Gateway category, CancellationToken cancellationToken);

    Task<DefaultResponseDto<IEnumerable<Gateway>>> GetAll(CancellationToken cancellationToken);
    Task<DefaultResponseDto<Gateway>> Get(CancellationToken cancellationToken);
    Task<DefaultResponseDto<Gateway>> Update(Gateway category, CancellationToken cancellationToken);
    Task<DefaultResponseDto<bool>> Delete(int id, CancellationToken cancellationToken);
    Task<DefaultResponseDto<dynamic>> Execute(string code, dynamic parameters, CancellationToken cancellationToken);
}
