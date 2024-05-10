using Locamoto.UseCases.Orders.AcceptOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Orders;

public class AcceptOrderEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/order/{orderID}/deliveryman/{deliverymanID}/accept", async (
            [FromRoute] Guid orderID,
            [FromRoute] Guid deliverymanID,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new AcceptOrderCommand(
               OrderID: orderID,
               DeliverymanID: deliverymanID
            );

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.NoContent();

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("AcceptOrder")
        .WithTags("Orders")
        .WithOpenApi();
    }
}
