using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;

namespace Locamoto.UseCases.DeliveryDrivers.Create;
public class CreateDeliverymanCommandHandler(IDeliverymanRepository deliverymanRepository) 
    : IRequestHandler<CreateDeliverymanCommand, CreateDeliverymanCommandResponse>
{
    readonly IDeliverymanRepository _deliverymanRepository = deliverymanRepository;

    public async Task<CreateDeliverymanCommandResponse> Handle(CreateDeliverymanCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateDeliverymanCommandResponse();

        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            if (await _deliverymanRepository.ExistsCnh(request.Cnh.ToString()))
            {
                response.AddError("CNH already registered");
                return response;
            }

            if (await _deliverymanRepository.ExistsCnpj(request.Cnpj.ToString()))
            {
                response.AddError("CNPJ already registered");
                return response;
            }

            var deliveryman = new Deliveryman(
                name: request.Name,
                cnh: request.Cnh,
                birthDate: request.BirthDate,
                cnpj: request.Cnpj
            );

            await _deliverymanRepository.Create(deliveryman);
            await _deliverymanRepository.SaveChanges();

            response.DeliverymanID = deliveryman.Id;
        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception)
        {
            throw;
        }

        return response;
    }
}
