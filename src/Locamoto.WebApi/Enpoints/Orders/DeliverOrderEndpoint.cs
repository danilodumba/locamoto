using Locamoto.UseCases.Orders.DeliverOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Orders;

public class DeliverOrderEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/order/{orderID}/deliveryman/{deliverymanID}/deliver", async (
            [FromRoute] Guid orderID,
            [FromRoute] Guid deliverymanID,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new DeliverOrderCommand(
               OrderID: orderID,
               DeliverymanID: deliverymanID
            );

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.NoContent();

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("DeliverOrder")
        .WithTags("Orders")
        .WithOpenApi();
    }
}
