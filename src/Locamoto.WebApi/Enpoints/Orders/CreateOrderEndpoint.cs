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

            if (response.IsValid()) return Results.Created(string.Empty, response);

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("CreateOrder")
        .WithTags("Orders")
        .Produces(201)
        .Produces(400, typeof(List<string>))
        .Produces(500, typeof(ProblemDetails))
        .WithOpenApi();
    }
}
