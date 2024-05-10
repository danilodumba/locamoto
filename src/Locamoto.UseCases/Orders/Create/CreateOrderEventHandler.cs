using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.UseCases.Orders.Create.Notifications;
using MediatR;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderEventHandler : INotificationHandler<CreateOrderNotificationEvent>
{
    readonly IOrdeDeliverymanNotificationRepository _ordeDeliverymanNotificationRepository;
    readonly IDeliverymanRepository _deliverymanRepository;

    public CreateOrderEventHandler(IOrdeDeliverymanNotificationRepository ordeDeliverymanNotificationRepository, IDeliverymanRepository deliverymanRepository, ICreateOrderNotification createOrderNotification)
    {
        _ordeDeliverymanNotificationRepository = ordeDeliverymanNotificationRepository;
        _deliverymanRepository = deliverymanRepository;
    }

    public async Task Handle(CreateOrderNotificationEvent request, CancellationToken cancellationToken)
    {   
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
