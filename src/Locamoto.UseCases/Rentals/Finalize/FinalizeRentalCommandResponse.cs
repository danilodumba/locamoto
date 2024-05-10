using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Rentals.Finalize
{
    public record FinalizeRentalCommandResponse: CommandResponse
    {
        public decimal CostTotal { get; set; }
    }
}