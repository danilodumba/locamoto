using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Motorcycles.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Motorcycle
{
    public class CreateMotorcycleEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
             app.MapPost("/motorcycle", async (
                [FromBody] CreateMotorcycleCommand command,
                IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(command, cancellationToken);

                if (response.IsValid()) return Results.Created(string.Empty, response.MotorcicleID);

                return Results.BadRequest(response.GetErrors());
            })
            .WithName("CreteMotorcycle")
            .WithTags("Motorcycle")
            .Produces(201, typeof(Guid))
            .Produces(400, typeof(List<string>))
            .Produces(500, typeof(ProblemDetails))
            .WithOpenApi();
        }
    }
}