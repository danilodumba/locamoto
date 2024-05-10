using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Entities;
using Locamoto.Domain.Exceptions;
using Xunit;

namespace Locamoto.UnitTest.Domains
{
    public class MotorcycleTest
    {
        [Theory]
        [InlineData(0, "QXI8739", "Yamaha 357")]
        [InlineData(2024, "", "Honda Titan")]
        [InlineData(1999, "QXI8730", "")]
        public void Must_Validate_Madatory_Fields(int year, string plate, string model)
        {
            Assert.Throws<DomainException>(() => 
            {
                var motorcycle = new Motorcycle(year, model, plate);
            });
        }

        [Fact]
        public void Must_Validate_Update_Plate()
        {
            Motorcycle motorcycle = new(2024, "Honda PCX", "AAA99999");

            motorcycle.SetPlate("ABC1234");

            Assert.True("ABC1234".Equals(motorcycle.Plate), "Plate not changed");
        }
    }
}