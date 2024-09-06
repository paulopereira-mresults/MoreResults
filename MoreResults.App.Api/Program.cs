using MoreResults.App.Api;
using MoreResults.App.IoC;

var builder = WebApplication.CreateBuilder(args);

// Adicione o DbContext ao contêiner de DI
builder.ConfigureDatabase("Default");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura a ingeção de dependência
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
