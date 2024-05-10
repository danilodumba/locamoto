using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Entities;

namespace Locamoto.UnitTest.Domains.Motorcycles
{
    public static class MotorcycleMock
    {
        public static Motorcycle GetMotorcycle()
        {
            return new Motorcycle(2000, "HONDA PCX", "XXX0X989");
        }
    }
}