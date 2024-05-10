using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using Locamoto.UseCases.Orders.Create.Notifications;
using MediatR;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderCommandHandler(IOrderRepository orderRepository, ICreateOrderNotification createOrderNotification) : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly ICreateOrderNotification _createOrderNotification = createOrderNotification;

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
        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception)
        {
            throw;
        }

        return response;
    }
}