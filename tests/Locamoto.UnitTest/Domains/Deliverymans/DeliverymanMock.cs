using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Entities;
using Locamoto.Domain.ValueObjects;

namespace Locamoto.UnitTest.Domains.Deliverymans
{
    public static class DeliverymanMock
    {
        public static Deliveryman GetDeliveryman()
        {
            return new Deliveryman("Joao", new CNPJ("56403821000123"), new DateOnly(1990, 8, 15), new CnhCard("1234556", CnhType.AB, string.Empty));
        }

        public static Deliveryman GetDeliverymanCnhTypeB()
        {
            return new Deliveryman("Pedro", new CNPJ("89624374000191"), new DateOnly(1982, 1, 23), new CnhCard("2334320998", CnhType.B, string.Empty));
        }
    }
}