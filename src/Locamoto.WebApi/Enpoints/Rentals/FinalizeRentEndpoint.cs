using Locamoto.UseCases.Rentals.Create;
using Locamoto.UseCases.Rentals.Finalize;
using Locamoto.WebApi.Enpoints.Rentals.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Rentals;

public class FinalizeRentEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/rent/finalize", async (
            [FromBody] FinalizeRentRequest request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var command = new FinalizeRentalCommand(
               Plate: request.Plate,
               EndDate: DateOnly.FromDateTime(request.EndDate)
            );

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.Ok(response);

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("FinalizeRent")
        .WithTags("Rentals")
        .WithOpenApi();
    }
}

