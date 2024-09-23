using App.Business.Features.Abstractions;
using App.Business.Interfaces;
using App.Domain.Dto;
using App.Domain.Dto.Tools;
using App.Domain.Entities.Tools;
using App.IoC;
using Dapper;
using Microsoft.Data.SqlClient;

namespace App.Business.Features.Tools.Gateways.Commands;

public class ExecuteDatabaseGatewayCommandHandler : FeatureAbstract<GatewayCategory>, IFeature<DefaultResponseDto<object>, GatewayRequestExecutionDto>
{
    public ExecuteDatabaseGatewayCommandHandler(IRepositories repositories) : base(repositories) { }

    public async Task<DefaultResponseDto<object>> Handle(GatewayRequestExecutionDto command, CancellationToken cancellationToken)
    {
        string connectionString = "";

        await using (var connection = new SqlConnection(connectionString))
        {
            var parameters = new DynamicParameters();

            foreach (GatewayParameter parameter in command.Gateway.Parameters)
            {
                parameters.Add(parameter.Name, parameter.Value);
            }

            object result;

            if (command.Method == HttpMethod.Get)
            {
                result = await connection.ExecuteAsync(command.Gateway.Content, parameters);
            }
            else
            {
                result = await connection.QueryAsync(connectionString, parameters);
            }
        }

        return DefaultResponseDto<dynamic>.Create(false);
    }
}
