using System.Text;
using Locamoto.UseCases.Orders.Create.Notifications;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Locamoto.Infra.RabbitMQ.Publishers;
public class CreateOrderNotificationPublisher(string connectionString) : PublisherCore(connectionString), ICreateOrderNotification
{
    public Task Send(CreateOrderMessage message)
    {
        var properties = _model.CreateBasicProperties();
        properties.Persistent = false;
        var stringJson = JsonConvert.SerializeObject(message);
        byte[] messagebuffer = Encoding.Default.GetBytes(stringJson);
        _model.BasicPublish(RabbitMQSchema.QueueCreateOrder, RabbitMQSchema.QueueCreateOrder, properties, messagebuffer);

        return Task.CompletedTask;
    }
}
