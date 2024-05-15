
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.DeliveryDrivers.Create;

public record CreateDeliverymanCommandResponse: CommandResponse
{
    public Guid DeliverymanID { get; set; }
}

