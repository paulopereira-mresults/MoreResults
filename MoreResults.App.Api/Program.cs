using MoreResults.App.Api;
using MoreResults.App.IoC;

var builder = WebApplication.CreateBuilder(args);

// Adicione o DbContext ao cont�iner de DI
builder.ConfigureDatabase("Default");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
