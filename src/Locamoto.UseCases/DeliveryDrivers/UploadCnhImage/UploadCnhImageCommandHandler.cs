using Locamoto.Domain.Repositories;
using Locamoto.Domain.ValueObjects;
using Locamoto.UseCases.DeliveryDrivers.Services;
using MediatR;

namespace Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;
public class UploadCnhImageCommandHandler(IDeliverymanRepository deliverymanRepository, IStorageCnhService storageCnhService) : IRequestHandler<UploadCnhImageCommand, UploadCnhImageResponse>
{
    readonly IDeliverymanRepository _deliverymanRepository = deliverymanRepository;
    readonly IStorageCnhService _storageCnhService = storageCnhService;

    public async Task<UploadCnhImageResponse> Handle(UploadCnhImageCommand request, CancellationToken cancellationToken)
    {
        var response = new UploadCnhImageResponse();

        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

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

        string cnhImage = request.FileName;

        await _storageCnhService.Publish(new CnhFile(cnhImage, filePath, "locamoto"));

        var cnh = new CnhCard(deliveryman.Cnh.Number, deliveryman.Cnh.Type, cnhImage);
        deliveryman.SetCnh(cnh);

        await _deliverymanRepository.Update(deliveryman);
        await _deliverymanRepository.SaveChanges();

        return response;
    }
}
