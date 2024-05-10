using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;

namespace Locamoto.UseCases.Motorcycles.Update;

public class UpdateMotorcycleCommandHandler(IMotorcycleRepository motorcycleRepository) 
    : IRequestHandler<UpdateMotorcycleCommand, UpdateMotorcycleCommandResponse>
{
    readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;

    public async Task<UpdateMotorcycleCommandResponse> Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateMotorcycleCommandResponse();

        if (!request.IsValid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            if (await _motorcycleRepository.ExistsPlate(request.Plate))
            {
                response.AddError("Plate already registered");
                return response;
            }

            var motorcycle = await _motorcycleRepository.GetById(request.MotorcycleID);
            if (motorcycle is null)
            {
                response.AddError("Motorcycle not found");
                return response;
            }

            motorcycle.SetPlate(request.Plate);

            await _motorcycleRepository.Update(motorcycle);
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
