using System.Net;
using Locamoto.UseCases.DeliveryDrivers.Services;
using Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Minio;

namespace Locamoto.WebApi.Enpoints.Deliverymans;

public class SendImageCnhDeliverymanEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/deliveryman/{deliverymanID}/image-cnh", async (
            [FromRoute] Guid deliverymanID,
            [FromForm] IFormFile formFile,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Stream streamFile = formFile.OpenReadStream();

            UploadCnhImageCommand command = new (deliverymanID, formFile.FileName, streamFile);

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.NoContent();

            return Results.BadRequest(response.GetErrors());
        })
        .DisableAntiforgery()
        .WithName("SendImageCNHDeliveryman")
        .WithTags("Deliveryman")
        .Produces(204)
        .Produces(400, typeof(List<string>))
        .Produces(500, typeof(ProblemDetails))
        .WithOpenApi();
    }
}
