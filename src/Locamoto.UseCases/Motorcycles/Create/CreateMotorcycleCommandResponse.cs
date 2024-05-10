using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Motorcycles.Create;

public record CreateMotorcycleCommandResponse: CommandResponse
{
    public Guid MotorcicleID { get; set; }
}

