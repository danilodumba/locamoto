using Locamoto.UseCases.Rentals.Create;
using Locamoto.WebApi.Enpoints.Rentals.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Rentals;

public class CreateRentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/rent", async (
            [FromBody] CreateRentRequest request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateRentCommand(
               DeliverymanID: request.DeliverymanID,
               PlanID: request.PlanID
            );

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.Ok(response);

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("CreateRent")
        .WithTags("Rentals")
        .WithOpenApi();
    }
}

