using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Motorcycles.Remove;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Motorcycle
{
    public class RemoveMotorcycleEnpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("/motorcycle/{id}", async (
                [FromRoute] Guid id,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var command = new RemoveMotorcycleCommand(id);
                var response = await mediator.Send(command, cancellationToken);

                if (response.IsValid()) return Results.NoContent();

                return Results.BadRequest(response.GetErrors());
            })
            .WithName("RemoveMotorcycle")
            .WithTags("Motorcycle")
            .WithOpenApi();
        }
    }
}