using Locamoto.Domain.Services;
using MediatR;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderEventHandler : IRequestHandler<CreateOrderNotificationEvent>
{
    //readonly IMessageBrokerService _messageBrokerService = messageBrokerService;

    public  Task Handle(CreateOrderNotificationEvent request, CancellationToken cancellationToken)
    {
        return   Task.CompletedTask;
    }
}
