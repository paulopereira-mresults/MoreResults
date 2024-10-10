using App.Api;
using App.IoC;
using App.Shared.Constants;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione o DbContext ao cont�iner de DI
builder.ConfigureDatabase("Default");
builder.ConfigureSchedules("Hangfire");
builder.ConfigureAuthentication();

builder
    .Services
    .AddControllers().ConfigureApiBehaviorOptions(options =>
    {
      /**
       * Suprime a validacao de ModelState padrao do .NET.
       * @see https://stackoverflow.com/questions/54942192/how-can-i-customize-the-error-response-in-web-api-with-net-core
       */
      options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
  option.EnableAnnotations();

  option.SwaggerDoc(
    SystemModules.CORE,
    new OpenApiInfo
    {
      Title = SystemModules.CORE,
      Version = "1",
      Description = SystemModules.CORE
    });


  #region Autentica��o JWT Bearer
  option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
  {
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Autenticação por Bearer/JWT pe obrigatória no sistema. \r\n\r\n Digite 'Bearer' [espaço] seguido do token no campo logo abaixo.\r\n\r\nExemplo: \"Bearer abc123\"",
  });

  /* https://www.freecodespot.com/blog/use-jwt-bearer-authorization-in-swagger/#VIII_Configure_Swagger_to_accept_Header_Authorization */
  option.AddSecurityRequirement(new OpenApiSecurityRequirement{
          {
           new OpenApiSecurityScheme
           {
             Reference = new OpenApiReference
             {
               Type = ReferenceType.SecurityScheme,
               Id = "Bearer"
             }
           },
            new string[] {}
          }
        });
  #endregion

  //var filePath = Path.Combine(AppContext.BaseDirectory, "api.xml");
  //option.IncludeXmlComments(filePath);
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configura a inge��o de depend�ncia
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseMiddlewares();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint($"{SystemModules.CORE}/swagger.json", nameof(SystemModules.CORE) + " - V1");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHangfireDashboard();
app.UseJwt();
app.Run();
