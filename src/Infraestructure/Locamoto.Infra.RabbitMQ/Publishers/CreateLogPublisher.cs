using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Locamoto.Infra.RabbitMQ.Publishers;
public class CreateLogPublisher : PublisherCore
{
    public CreateLogPublisher(string connectionString) : base(connectionString)
    {
    }

    public Task Send(object message)
    {
        var properties = _model.CreateBasicProperties();
        properties.Persistent = false;
        var stringJson = JsonConvert.SerializeObject(message);
        byte[] messagebuffer = Encoding.Default.GetBytes(stringJson);
        _model.BasicPublish(RabbitMQSchema.QueueCreateOrder, RabbitMQSchema.QueueCreateOrder, properties, messagebuffer);

        return Task.CompletedTask;
    }
}