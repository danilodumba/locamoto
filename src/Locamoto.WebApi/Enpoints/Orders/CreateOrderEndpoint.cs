using Locamoto.UseCases.Orders.Create;
using Locamoto.WebApi.Enpoints.Orders.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Orders;
public class CreateOrderEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/order", async (
            [FromBody] CreateOrderRequest request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateOrderCommand(
               Cost: request.Cost
            );

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.Ok(response);

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("CreateOrder")
        .WithTags("Orders")
        .WithOpenApi();
    }
}
