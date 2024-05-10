using RabbitMQ.Client;

namespace Locamoto.Infra.RabbitMQ.Publishers;

public abstract class PublisherCore
{
    readonly string _connectionString;
    protected IModel _model;
    protected PublisherCore(string connectionString)
    {
         _connectionString = connectionString;
        var connectionFactory = new ConnectionFactory();
        var connection = connectionFactory.CreateConnection(_connectionString);
        _model = connection.CreateModel();
    }
}