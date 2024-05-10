using Locamoto.Infra.RabbitMQ.Consumers.Messages;
using Locamoto.UseCases.Orders.Create;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.Infra.RabbitMQ.Consumers
{
    public class OrderCreatedNotificationConsumer(IMediator mediator, ILogger<OrderCreatedNotificationConsumer> logger) 
        : IConsumer<OrderCreateNotificationMessage>
    {
        readonly IMediator _mediator = mediator;
        readonly ILogger<OrderCreatedNotificationConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<OrderCreateNotificationMessage> context)
        {
            try
            {
                var message = context.Message;

                CreateOrderNotificationEvent createOrderNotificationEvent = new(message.OrderID, message.Cost, message.CreatedDate);
                await _mediator.Publish(createOrderNotificationEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail to read queue for crete order.");
            }
        }
    }
}