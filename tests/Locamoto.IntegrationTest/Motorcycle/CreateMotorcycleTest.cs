using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Motorcycle.Mocks;

namespace Locamoto.IntegrationTest.Motorcycle
{
    public class CreateMotorcycleTest : HttpServiceBase
    {
        public CreateMotorcycleTest() : base("motorcycle")
        {
        }

        [Fact]
        public async Task Must_Create_Motorcycle_StatusOk()
        {
            var motorcycle = MotorcycleMock.GetMotorcycleMock();
            var response = await this.Post(string.Empty, motorcycle);

            Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
        }
    }
}