using App.Api;
using App.Infrastructure.Contexts;
using App.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione o DbContext ao cont�iner de DI
builder.ConfigureDatabase("Default");

builder
    .Services
    .AddControllers().ConfigureApiBehaviorOptions(options =>
    {
      /**
       * Suprime a valida��o de ModelState padr�o do .NET.
       * @see https://stackoverflow.com/questions/54942192/how-can-i-customize-the-error-response-in-web-api-with-net-core
       */
      options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configura a inge��o de depend�ncia
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseMiddlewares();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
