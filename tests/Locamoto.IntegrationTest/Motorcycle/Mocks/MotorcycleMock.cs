using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Locamoto.UseCases.Motorcycles.Create;

namespace Locamoto.IntegrationTest.Motorcycle.Mocks
{
    public static class MotorcycleMock
    {
        public static CreateMotorcycleCommand GetMotorcycleMock()
        {
            var faker = new Faker("pt_BR");
            
            var command = new CreateMotorcycleCommand(
                Year: faker.Random.Int(1990, 2024),
                Model: faker.Vehicle.Model(),
                Plate: faker.Random.String2(3).ToUpper() + faker.Random.Int(1111, 9999)
            );

            return command;
        }
    }
}