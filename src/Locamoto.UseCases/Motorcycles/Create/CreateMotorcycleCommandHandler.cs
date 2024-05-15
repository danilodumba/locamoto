using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.Motorcycles.Create;
public class CreateMotorcycleCommandHandler(IMotorcycleRepository motorcycleRepository, ILogger<CreateMotorcycleCommandHandler> logger)
    : IRequestHandler<CreateMotorcycleCommand, CreateMotorcycleCommandResponse>
{
    readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    readonly ILogger<CreateMotorcycleCommandHandler> _logger = logger;

    public async Task<CreateMotorcycleCommandResponse> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateMotorcycleCommandResponse();

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

            var motorcycle = new Motorcycle(
                year: request.Year,
                model: request.Model,
                plate: request.Plate
            );

            await _motorcycleRepository.Create(motorcycle);
            await _motorcycleRepository.SaveChanges();

            response.MotorcicleID = motorcycle.Id;
        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to create Motorcycle");
            throw;
        }

        return response;
    }
}
