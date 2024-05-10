using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Rentals.Create
{
    public record CreateRentCommandResponse: CommandResponse
    {
        public Guid RentID { get; set; }
        public decimal ExpectedCost { get; set; }
        public string MotorcyclePlate { get; set; } = string.Empty;
        public DateOnly ExpectedEndDate { get; set; }
        public DateOnly StartDate { get; set; }
    }
}