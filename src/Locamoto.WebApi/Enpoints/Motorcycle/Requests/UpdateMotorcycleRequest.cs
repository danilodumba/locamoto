using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.WebApi.Enpoints.Motorcycle.Requests
{
    public record UpdateMotorcycleRequest
    {
        public string Plate { get; set; } = "";
    }
}