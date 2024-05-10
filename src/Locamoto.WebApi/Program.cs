using Locamoto.Infra.PostgreSql.Extensions;
using Locamoto.WebApi.Enpoints;
using Locamoto.UseCases.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints();
builder.Services.AddUseCases();
builder.Services.AddInfraPostgreSql(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints(); 
app.Run();

