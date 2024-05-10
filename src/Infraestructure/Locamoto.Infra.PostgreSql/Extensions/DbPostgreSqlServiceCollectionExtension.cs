using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.PostgreSql.Queries;
using Locamoto.Infra.PostgreSql.Repositories;
using Locamoto.UseCases.CostPlans.Queries;
using Locamoto.UseCases.Motorcycles.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locamoto.Infra.PostgreSql.Extensions;

public static class DbPostgreSqlServiceCollectionExtension
{
    public static void AddInfraPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(LocamotoEFContextSchema.DefualtConnectionStringName);
        ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

        services.AddDbContext<LocamotoEFContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IRentRepository, RentRepository>();
        services.AddScoped<IDeliverymanRepository, DeliverymanRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
        services.AddScoped<ICostPlanRepository, CostPlanRepository>();

        services.AddTransient<ICostPlanServiceQuery>(x => new CostPlanQuery(connectionString));
        services.AddTransient<IMotorcycleQuery>(x => new MotorcycleQuery(connectionString));
    }
}
