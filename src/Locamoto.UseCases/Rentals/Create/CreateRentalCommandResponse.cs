using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Rentals.Create
{
    public record CreateRentCommandResponse: CommandResponse
    {
        public Guid RentID { get; set; }
        public decimal ExpectedCost { get; set; }
        public DateOnly ExpectedEndDate { get; set; }
        public DateOnly StartDate { get; set; }
        public MotorcycleCreateRentCommandResponse Motorcycle { get; set; } = new MotorcycleCreateRentCommandResponse();
        public DeliverymanCreateRentCommandResponse Deliveryman { get; set; } = new DeliverymanCreateRentCommandResponse();
    }

    public record DeliverymanCreateRentCommandResponse
    {
        public Guid DeliverymanID { get; set; }
        public string Name{ get; set; } = string.Empty;
    }

    public record MotorcycleCreateRentCommandResponse
    {
        public string Model { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public Guid MotorcycleID { get; set; }
    }
}