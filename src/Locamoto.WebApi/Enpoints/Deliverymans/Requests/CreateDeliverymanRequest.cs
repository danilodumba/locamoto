using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.WebApi.Enpoints.Deliverymans.Requests
{
    public record CreateDeliverymanRequest
    {
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Cnpj { get; set; } = "";
        public CnhModel Cnh { get; set; } = new CnhModel();
    }

    public record CnhModel
    {
        public string Number { get; set; } = "";
        public string Type { get; set; } = "A";
    }
}