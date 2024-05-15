using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.UseCases.Orders.Create.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderEventHandler : INotificationHandler<CreateOrderNotificationEvent>
{
    readonly IOrdeDeliverymanNotificationRepository _ordeDeliverymanNotificationRepository;
    readonly IDeliverymanRepository _deliverymanRepository;
    readonly ILogger<CreateOrderEventHandler> _logger;

    public CreateOrderEventHandler(IOrdeDeliverymanNotificationRepository ordeDeliverymanNotificationRepository, IDeliverymanRepository deliverymanRepository, ICreateOrderNotification createOrderNotification, ILogger<CreateOrderEventHandler> logger)
    {
        _ordeDeliverymanNotificationRepository = ordeDeliverymanNotificationRepository;
        _deliverymanRepository = deliverymanRepository;
        _logger = logger;
    }

    public async Task Handle(CreateOrderNotificationEvent request, CancellationToken cancellationToken)
    {   
        _logger.LogInformation("Init create notification Event.");
        var deliverymanList = await _deliverymanRepository.ListDeliverymenWithRentAndWithoutOrder();

        foreach (var item in deliverymanList)
        {
            var orderNotification = new OrderNotification(request.OrderID, request.Cost, request.CreatedAt);
            var deliverymanNotification = new DeliverymanNotification(item.Id, item.Name);
            var orderDeliverymanNotification = new OrderDeliverymanNotification(orderNotification, deliverymanNotification);

            await _ordeDeliverymanNotificationRepository.Create(orderDeliverymanNotification);
        }
    }
}
