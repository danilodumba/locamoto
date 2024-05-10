using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Locamoto.Domain.Repositories;
using MediatR;

namespace Locamoto.UseCases.Rentals.Create;

public class CreateRentCommandHandler(
    IRentRepository rentRepository,
    ICostPlanRepository costPlanRepository,
    IMotorcycleRepository motorcycleRepository,
    IDeliverymanRepository deliverymanRepository) : IRequestHandler<CreateRentCommand, CreateRentCommandResponse>
{
    readonly IRentRepository _rentRepository = rentRepository;
    readonly ICostPlanRepository _costPlanRepository = costPlanRepository;
    readonly IMotorcycleRepository _motorcycleRepository = motorcycleRepository;
    readonly IDeliverymanRepository _deliverymanRepository = deliverymanRepository;

    public async Task<CreateRentCommandResponse> Handle(CreateRentCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateRentCommandResponse();
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

            var motorcycle = await GetMotorcycleAvailable();
            if (motorcycle is null)
            {
                response.AddError("There are no motorcycles available for rent.");
                return response;
            }

            var plan = await _costPlanRepository.GetById(request.PlanID);
            if (plan is null)
            {
                response.AddError("There is no plan for this number of days");
                return response;
            }

            var rent = new Rent(
                motorcycle: motorcycle,
                deliveryman: deliveryman,
                plan: plan
            );

            await _rentRepository.Create(rent);
            await _rentRepository.SaveChanges();

            response.MotorcyclePlate = motorcycle.Plate;
            response.RentID = rent.Id;
            response.ExpectedCost = rent.ExpectedCost;
            response.ExpectedEndDate = rent.ExpectedEndDate;
            response.StartDate = rent.StartDate;

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

    private async Task<Motorcycle?> GetMotorcycleAvailable()
    {
        return await _motorcycleRepository.GetMotorcycleAvailble();
    }
}
