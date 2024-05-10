using Locamoto.Domain.Repositories;
using Locamoto.Infra.MongoDB.Contexts;
using Locamoto.Infra.MongoDB.Queries;
using Locamoto.Infra.MongoDB.Repositories;
using Locamoto.UseCases.Orders.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locamoto.Infra.MongoDB.Extensions;
public static class MongoDBServiceCollectionExtension
{
    public static void AddInfraMongoDB(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(MongoContextSchema.DefualtConnectionStringName);
        ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

        services.AddScoped<IOrdeDeliverymanNotificationRepository>(p => new OrderDeliverymanNotificationRepository(connectionString));
        
        services.AddTransient<IOrderDeliverymanNotificationQuery>(p => new OrderDeliverymanNotificationQuery(connectionString));
    }
}
