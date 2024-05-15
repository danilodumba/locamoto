using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using Locamoto.UseCases.Orders.Create.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderCommandHandler(IOrderRepository orderRepository, ICreateOrderNotification createOrderNotification, ILogger<CreateOrderCommandHandler> logger) : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly ICreateOrderNotification _createOrderNotification = createOrderNotification;
    readonly ILogger<CreateOrderCommandHandler> _logger = logger;

    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateOrderResponse();
        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var order = new Order(request.Cost);

            await _orderRepository.Create(order);
            await _orderRepository.SaveChanges();

            await _createOrderNotification.Send(new CreateOrderMessage
            {
                OrderID = order.Id,
                Cost = order.Cost,
                CreatedDate = order.CreatedAt
            });

            response.OrderID = order.Id;
        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to create Order");
            throw;
        }

        return response;
    }
}