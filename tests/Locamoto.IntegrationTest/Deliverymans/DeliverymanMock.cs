using Bogus;
using Bogus.Extensions.Brazil;
using Locamoto.WebApi.Enpoints.Deliverymans.Requests;

namespace Locamoto.IntegrationTest.Deliverymans
{
    public static class DeliverymanMock
    {
        public static CreateDeliverymanRequest GetDeliveryman()
        {
            var faker = new Faker("pt_BR");
            
            var request = new CreateDeliverymanRequest
            {
                Name = faker.Name.FullName(),
                BirthDate = faker.Date.Between(new DateTime(1970, 1, 1), new DateTime(2005,1,1)),
                Cnpj = faker.Company.Cnpj(),
                Cnh = new CnhModel
                {
                    Number = faker.Random.Int(1111111, 9999999).ToString(),
                    Type = "AB"
                }
            };

            return request;
        }
    }
}