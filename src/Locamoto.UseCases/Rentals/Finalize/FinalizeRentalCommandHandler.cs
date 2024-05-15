using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Locamoto.UseCases.Rentals.Finalize;

public class FinalizeRentalCommandHandler(
    IRentRepository rentRepository, 
    ILogger<FinalizeRentalCommandHandler> logger) : IRequestHandler<FinalizeRentalCommand, FinalizeRentalCommandResponse>
{
    readonly IRentRepository _rentRepository = rentRepository;
    readonly ILogger<FinalizeRentalCommandHandler> _logger = logger;

    public async Task<FinalizeRentalCommandResponse> Handle(FinalizeRentalCommand request, CancellationToken cancellationToken)
    {
        var response = new FinalizeRentalCommandResponse();
        if (request.IsInvalid())
        {
            response.AddError(request.GetErrors());
            return response;
        }

        try
        {
            var rent = await _rentRepository.GetByMotorcyclePlate(request.Plate);
            if (rent is null)
            {
                response.AddError("Rent not found.");
                return response;
            }

            rent.FinalizeRental(request.EndDate);

            await _rentRepository.Update(rent);
            await _rentRepository.SaveChanges();

            response.CostTotal = rent.CostTotal();

        }
        catch (DomainException ex)
        {
            response.AddError(ex.Message);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error to finalize Rental");
            throw;
        }

        return response;
    }
}
