using Locamoto.Domain.Repositories;
using Locamoto.Domain.ValueObjects;
using Locamoto.UseCases.DeliveryDrivers.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;
public class UploadCnhImageCommandHandler(
    IDeliverymanRepository deliverymanRepository,
    IStorageCnhService storageCnhService,
    ILogger<UploadCnhImageCommandHandler> logger) : IRequestHandler<UploadCnhImageCommand, UploadCnhImageResponse>
{
    readonly IDeliverymanRepository _deliverymanRepository = deliverymanRepository;
    readonly IStorageCnhService _storageCnhService = storageCnhService;
    readonly ILogger<UploadCnhImageCommandHandler> _logger = logger;

    public async Task<UploadCnhImageResponse> Handle(UploadCnhImageCommand request, CancellationToken cancellationToken)
    {
        var response = new UploadCnhImageResponse();

        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var deliveryman = await _deliverymanRepository.GetById(request.DeliverymanID);
            if (deliveryman is null)
            {
                response.AddError("Deliveryman not found.");
                return response;
            }

            var filePath = Path.GetTempFileName();
            using (var stream = File.Create(filePath))
            {
                await request.File.CopyToAsync(stream);
            }

            string cnhImage = $"CNH-{request.DeliverymanID}.{request.GetFileExtension()}";

            await _storageCnhService.Publish(new CnhFile(cnhImage, filePath, "locamoto"));

            var cnh = new CnhCard(deliveryman.Cnh.Number, deliveryman.Cnh.Type, cnhImage);
            deliveryman.SetCnh(cnh);

            await _deliverymanRepository.Update(deliveryman);
            await _deliverymanRepository.SaveChanges();

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to send CNH image.");
            throw;
        }
    }
}
