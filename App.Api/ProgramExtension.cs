using App.Api.Middlewares;
using App.Infrastructure.Contexts;
using App.Shared.Filters;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MySql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Transactions;

namespace App.Api;

public static class ProgramExtension
{
  /// <summary>
  /// Configura o uso de autenticação JWT no sistema.
  /// </summary>
  public static IHostApplicationBuilder ConfigureAuthentication(this IHostApplicationBuilder builder)
  {
    string keyString = File.ReadAllText("private.key");
    var key = Encoding.ASCII.GetBytes(keyString);
    builder.Services.AddAuthentication(x =>
    {
      x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
      x.RequireHttpsMetadata = false;
      x.SaveToken = true;
      x.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
      };
    });

    return builder;
  }

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
  public static IHostApplicationBuilder ConfigureSchedules(this IHostApplicationBuilder builder, string nameOfConnectionString)
  {
    string connectionString = builder.Configuration.GetConnectionString(nameOfConnectionString);
    var serverVersion = ServerVersion.AutoDetect(connectionString);


    builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseStorage(new MySqlStorage(
          connectionString,
          new MySqlStorageOptions
          {
            TransactionIsolationLevel = IsolationLevel.ReadCommitted,
            QueuePollInterval = TimeSpan.FromSeconds(15),
            JobExpirationCheckInterval = TimeSpan.FromHours(1),
            CountersAggregateInterval = TimeSpan.FromMinutes(5),
            PrepareSchemaIfNecessary = true,
            DashboardJobListLimit = 100,
            TransactionTimeout = TimeSpan.FromMinutes(1)
          }
        ))
        .WithJobExpirationTimeout(TimeSpan.FromDays(1)));

    // Add the processing server as IHostedService
    builder.Services.AddHangfireServer();

    return builder;
  }

  /// <summary>
  /// Configura o dashboard do Hangfire
  /// </summary>
  public static WebApplication UseHangfireDashboard(this WebApplication builder)
  {
    builder.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
      Authorization = new[] { new DashboardNoAuthorizationFilter() },
      /**
       * Habilita o hangfire no servidor remoto
       * @see https://docs.hangfire.io/en/latest/configuration/using-dashboard.html#read-only-view
       */
      IsReadOnlyFunc = (DashboardContext context) => true
    });
    builder.MapHangfireDashboard();

    return builder;
  }

  public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<LogMiddleware>();
  }

  public static WebApplication UseJwt(this WebApplication builder)
  {
    builder.UseAuthentication();
    builder.UseAuthorization();

    return builder;
  }
}
