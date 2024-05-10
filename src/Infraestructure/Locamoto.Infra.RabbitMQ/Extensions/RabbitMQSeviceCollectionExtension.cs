using Locamoto.Infra.RabbitMQ.Consumers;
using Locamoto.Infra.RabbitMQ.Publishers;
using Locamoto.UseCases.Orders.Create.Notifications;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Locamoto.Infra.RabbitMQ.Extensions;

public static class RabbitMQSeviceCollectionExtension
{
    public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(RabbitMQSchema.DefualtConnectionStringName);
        var queue = RabbitMQSchema.QueueCreateOrder;

        ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

        //TODO: Revisar a confirguração do Masstransit.
        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumer<OrderCreatedNotificationConsumer>();
            cfg.UsingRabbitMq((context, config) =>
            {
                config.ReceiveEndpoint(queue, e =>
                {
                    e.ClearMessageDeserializers();
                    e.UseRawJsonSerializer();
                    e.ConfigureConsumer<OrderCreatedNotificationConsumer>(context);
                });

                config.Host(connectionString);
            });
        });

        services.AddMassTransitHostedService();

        services.AddTransient<ICreateOrderNotification>(p => new CreateOrderNotificationPublisher(connectionString));
    }
}
