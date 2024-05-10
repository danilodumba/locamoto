using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Domain.Services;
using Locamoto.Domain.Validations;
using MediatR;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderEventHandler : INotificationHandler<CreateOrderNotificationEvent>
{
    //readonly IMessageBrokerService _messageBrokerService = messageBrokerService;

    readonly IOrderRepository _orderRepository;
    readonly IOrdeDeliverymanNotificationRepository _ordeDeliverymanNotificationRepository;
    readonly IDeliverymanRepository _deliverymanRepository;

    public CreateOrderEventHandler(IOrderRepository orderRepository, IOrdeDeliverymanNotificationRepository ordeDeliverymanNotificationRepository, IDeliverymanRepository deliverymanRepository)
    {
        _orderRepository = orderRepository;
        _ordeDeliverymanNotificationRepository = ordeDeliverymanNotificationRepository;
        _deliverymanRepository = deliverymanRepository;
    }

    public async Task Handle(CreateOrderNotificationEvent request, CancellationToken cancellationToken)
    {   
        var order = await _orderRepository.GetById(request.OrderID);
        if (order is null) return;
        
        var deliverymanList = await _deliverymanRepository.ListDeliverymenWithRentAndWithoutOrder();

        foreach (var item in deliverymanList)
        {
            var orderNotification = new OrderNotification(order.Id, order.Cost, order.CreatedAt);
            var deliverymanNotification = new DeliverymanNotification(item.Id, item.Name);
            var orderDeliverymanNotification = new OrderDeliverymanNotification(orderNotification, deliverymanNotification);

            await _ordeDeliverymanNotificationRepository.Create(orderDeliverymanNotification);
        }
    }
}
