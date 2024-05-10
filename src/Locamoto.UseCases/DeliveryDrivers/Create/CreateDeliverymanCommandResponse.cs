using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.DeliveryDrivers.Create;

public record CreateDeliverymanCommandResponse: CommandResponse
{
    public Guid DeliverymanID { get; set; }
}

