namespace Locamoto.WebApi.Enpoints.Rentals.Requests;

public record CreateRentRequest(Guid DeliverymanID, Guid PlanID);
