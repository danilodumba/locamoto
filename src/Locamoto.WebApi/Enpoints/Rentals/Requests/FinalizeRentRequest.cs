namespace Locamoto.WebApi.Enpoints.Rentals.Requests;

public record FinalizeRentRequest(string Plate, DateTime EndDate);