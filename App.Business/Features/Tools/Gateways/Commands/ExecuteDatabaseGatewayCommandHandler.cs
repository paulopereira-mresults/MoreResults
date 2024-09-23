using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Entities.Tools;
using App.IoC;
using Dapper;
using Microsoft.Data.SqlClient;

namespace App.Business.Features.Tools.Gateways.Commands;

public class ExecuteDatabaseGatewayCommandHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<object>, Gateway>
{
    public ExecuteDatabaseGatewayCommandHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<object>> Handle(Gateway command, CancellationToken cancellationToken)
    {
        string connectionString = "";

        await using (var connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(command.Content);
        }

        return DefaultResponseDto<dynamic>.Create(false);
    }
}
