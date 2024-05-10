using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;

namespace Locamoto.UseCases.Motorcycles.Remove;

public class RemoveMotorcycleCommandHandler(
    IMotorcycleRepository motorcycleRepository,
    IRentRepository rentRepository) 
    : IRequestHandler<RemoveMotorcycleCommand, RemoveMotorcycleCommandResponse>
{
    readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    readonly IRentRepository _rentRepository = rentRepository;

    public async Task<RemoveMotorcycleCommandResponse> Handle(RemoveMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var response = new RemoveMotorcycleCommandResponse();

        if (!request.IsValid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var motorcycle = await _motorcycleRepository.GetById(request.MotorcycleID);
            if (motorcycle is null)
            {
                response.AddError("Motorcycle not found");
                return response;
            }

            if (await _rentRepository.ExistsRentForMotorcycle(request.MotorcycleID))
            {
                response.AddError("Motorcycle cannot be deleted because there is already a rental");
                return response;
            }

            await _motorcycleRepository.Remove(motorcycle);
            await _motorcycleRepository.SaveChanges();

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
