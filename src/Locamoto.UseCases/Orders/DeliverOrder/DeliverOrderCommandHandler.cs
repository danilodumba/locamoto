using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.Orders.DeliverOrder;

public class DeliverOrderCommandHandler(IDeliverymanRepository deliverymanRepository, IOrderRepository orderRepository, ILogger<DeliverOrderCommandHandler> logger) : IRequestHandler<DeliverOrderCommand, DeliverOrderResponse>
{
    readonly IDeliverymanRepository _deliverymanRepository = deliverymanRepository;
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly ILogger<DeliverOrderCommandHandler> _logger = logger;

    public async Task<DeliverOrderResponse> Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
    {
        var response = new DeliverOrderResponse();
        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var order = await _orderRepository.GetById(request.OrderID);
            if (order is null)
            {
                response.AddError("Order not found");
                return response;
            }

            var deliveryman = await _deliverymanRepository.GetById(request.DeliverymanID);

            order.Delivered();

            await _orderRepository.Update(order);
            await _orderRepository.SaveChanges();

        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to deliver Order");
            throw;
        }

        return response;
    }
}
  
