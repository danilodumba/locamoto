using Locamoto.Domain.ValueObjects;
using Locamoto.UseCases.DeliveryDrivers.Create;
using Locamoto.WebApi.Enpoints.Deliverymans.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Deliverymans;

public class CreateDeliverymanEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/deliveryman", async (
            [FromBody] CreateDeliverymanRequest request,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            CnhType cnhType = CnhType.A;
            //TODO: Melhorar essa tratativa de erro.
            try
            {
                cnhType = (CnhType)Enum.Parse(typeof(CnhType), request.Cnh.Type);
            }
            catch (Exception)
            {
                return Results.BadRequest("CNH Type invalid. Inform A, B or AB");
            }
            

            var command = new CreateDeliverymanCommand(
                Name: request.Name,
                Cnpj: new CNPJ(request.Cnpj),
                BirthDate: DateOnly.FromDateTime(request.BirthDate),
                Cnh: new CnhCard(request.Cnh.Number, cnhType)
            );

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.Ok(response.DeliverymanID);

            return Results.BadRequest(response.GetErrors());
        })
        .WithName("CreateDeliveryman")
        .WithTags("Deliveryman")
        .Produces(200, typeof(Guid))
        .Produces(400, typeof(List<string>))
        .Produces(500, typeof(ProblemDetails))
        .WithOpenApi();
        
    }
}
