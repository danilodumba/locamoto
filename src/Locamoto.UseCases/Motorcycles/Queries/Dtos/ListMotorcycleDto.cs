using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.UseCases.Motorcycles.Queries.Dtos
{
    public record ListMotorcycleDto()
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; } = "";
        public string Plate { get; set; } = "";
        public bool Available { get; set; }
    }
}