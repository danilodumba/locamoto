using Locamoto.Infra.PostgreSql.Extensions;
using Locamoto.WebApi.Enpoints;
using Locamoto.UseCases.Extensions;
using Locamoto.Infra.MongoDB.Extensions;
using Locamoto.Infra.RabbitMQ.Extensions;
using Locamoto.Infra.MinIO.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints();
builder.Services.AddUseCases();
builder.Services.AddInfraPostgreSql(builder.Configuration);
builder.Services.AddInfraMongoDB(builder.Configuration);
builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.AddInfraMinIO(builder.Configuration);
builder.Services.AddAntiforgery();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

   app.UseRouting();

    app.UseAuthentication(); // Must be after UseRouting()
    app.UseAuthorization(); // Must be after UseAuthentication()
app.UseAntiforgery();

app.MapEndpoints(); 
app.Run();

