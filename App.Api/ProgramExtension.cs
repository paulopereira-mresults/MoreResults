using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using App.Api.Middlewares;
using App.Infrastructure.Contexts;

namespace App.Api;

public static class ProgramExtension
{
  /// <summary>
  /// Configura a conexão principal com o banco de dados.
  /// </summary>
  public static IHostApplicationBuilder ConfigureDatabase(this IHostApplicationBuilder builder, string nameOfConnectionString)
  {
    string connectionString = builder.Configuration.GetConnectionString(nameOfConnectionString);
    var serverVersion = ServerVersion.AutoDetect(connectionString);

    /**
     * Configura��o de acesso ao Banco de Dados MySQL.
     * ***
     * Habilita��o do log de erros.
     * @see https://stackoverflow.com/questions/70198786/pomelo-entityframeworkcore-mysql-problem-when-access-property
     * ***
     * Ajuste para que n�o haja falhas em conex�es simult�neas.
     * @see https://stackoverflow.com/questions/48767910/entity-framework-core-a-second-operation-started-on-this-context-before-a-previ
     * ***
     * Ajuste para que haja uma espera razo�vel na consulta
     * @see https://stackoverflow.com/questions/62802173/consider-enabling-transient-error-resiliency-by-adding-enableretryonfailure
     */
    builder.Services.AddDbContext<DefaultContext>(options => options.UseMySql(
      connectionString,
      serverVersion
      ), ServiceLifetime.Transient);

    return builder;
  }

  /// <summary>
  /// Configura o módulo de agendamento de serviços e tarefas.
  /// </summary>
  public static IHostApplicationBuilder ConfigureSchedules(this IHostApplicationBuilder builder, string connectionString)
  {
    // Configurando o Hangfire para usar SQL Server
    builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString(connectionString), new SqlServerStorageOptions
        {
          CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
          SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
          QueuePollInterval = TimeSpan.Zero,
          UseRecommendedIsolationLevel = true,
          DisableGlobalLocks = true
        }));

    // Adicionando o servidor do Hangfire
    builder.Services.AddHangfireServer();

    return builder;
  }

  public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<LogMiddleware>();
  }

}
