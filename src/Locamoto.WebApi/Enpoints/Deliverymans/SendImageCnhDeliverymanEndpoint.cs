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
            CancellationToken cancellationToken, 
            IStorageCnhService service) =>
        {

            await service.GetFile(new CnhFile(formFile.FileName, "", "locamoto"));


            Stream streamFile = formFile.OpenReadStream();

            UploadCnhImageCommand command = new (deliverymanID, formFile.FileName, streamFile);

            var response = await mediator.Send(command, cancellationToken);

            if (response.IsValid()) return Results.NoContent();

            return Results.BadRequest(response.GetErrors());
        })
        .DisableAntiforgery()
        .WithName("SendImageCNHDeliveryman")
        .WithTags("Deliveryman")
        .WithOpenApi();
    }
}
