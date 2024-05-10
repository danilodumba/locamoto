using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;

namespace Locamoto.UseCases.Orders.Create;

public class CreateOrderCommandHandler(IOrderRepository orderRepository, IMediator mediator) : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    readonly IOrderRepository _orderRepository = orderRepository;
    readonly IMediator _mediator = mediator;

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

            CreateOrderNotificationEvent orderEvent = new(order.Id);
            await _mediator.Publish(orderEvent);
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