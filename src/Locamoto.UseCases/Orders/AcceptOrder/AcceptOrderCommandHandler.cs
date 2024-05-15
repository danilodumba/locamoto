using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.Orders.AcceptOrder;

public class AcceptOrderCommandHandler(IOrdeDeliverymanNotificationRepository orderNotificationRepository, IDeliverymanRepository deliverymanRepository, IOrderRepository orderRepository, ILogger<AcceptOrderCommandHandler> logger) : IRequestHandler<AcceptOrderCommand, AcceptOrderResponse>
{
    readonly IOrdeDeliverymanNotificationRepository _orderNotificationRepository = orderNotificationRepository;
    readonly IDeliverymanRepository _deliverymanRepository = deliverymanRepository;
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly ILogger<AcceptOrderCommandHandler> _logger = logger;

    public async Task<AcceptOrderResponse> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
    {
        var response = new AcceptOrderResponse();
        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            if (!await _orderNotificationRepository.HasNotificationForDeliveryman(request.OrderID, request.DeliverymanID))
            {
                response.AddError("You cannot accept this Order, because you dont have notification.");
                return response;
            }

            var order = await _orderRepository.GetById(request.OrderID);
            if (order is null)
            {
                response.AddError("Order not found");
                return response;
            }

            var deliveryman = await _deliverymanRepository.GetById(request.DeliverymanID);
            if (deliveryman is null)
            {
                response.AddError("Deliveryman not found");
                return response;
            }

            order.Accept(deliveryman);

            await _orderRepository.Update(order);
            await _orderRepository.SaveChanges();

            response.Cost = order.Cost;
            response.CreatedAt = order.CreatedAt;
            response.Deliveryman = order.Deliveryman?.Name ?? string.Empty;
            response.DeliverymanID = order.Deliveryman?.Id ?? Guid.Empty;
            response.OrderID = order.Id;

        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to accept Order");
            throw;
        }

        return response;
    }
}
  
