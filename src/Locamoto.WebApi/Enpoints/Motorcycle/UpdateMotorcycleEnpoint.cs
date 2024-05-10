using Locamoto.UseCases.Motorcycles.Update;
using Locamoto.WebApi.Enpoints.Motorcycle.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Motorcycle
{
    public class UpdateMotorcycleEnpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
             app.MapPut("/motorcycle/{id}", async (
                [FromRoute] Guid id,
                [FromBody] UpdateMotorcycleRequest request,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new UpdateMotorcycleCommand(id, request.Plate);
                var response = await mediator.Send(command, cancellationToken);

                if (response.IsValid()) return Results.NoContent();

                return Results.BadRequest(response.GetErrors());
            })
            .WithName("UpdateMotorcycle")
            .WithTags("Motorcycle")
            .WithOpenApi();
        }
    }
}