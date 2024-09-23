using App.Domain.Entities.Tools;
using App.IoC.Abstractions;

namespace App.IoC.Repositories.Tools;

public interface IGatewayRepository : IRepository<Gateway>
{
    Task<Gateway> GetByCodeAsync(string code);
}
