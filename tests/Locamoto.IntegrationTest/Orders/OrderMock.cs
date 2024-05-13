using Bogus;

namespace Locamoto.IntegrationTest.Orders
{
    public static class OrderMock
    {
        public static decimal GetCost()
        {
            var faker = new Faker("pt_BR");

            return Math.Round(faker.Random.Decimal(50, 10000), 2);
        }
    }
}