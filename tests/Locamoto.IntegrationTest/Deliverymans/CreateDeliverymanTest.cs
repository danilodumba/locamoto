
using Locamoto.IntegrationTest.Core;

namespace Locamoto.IntegrationTest.Deliverymans
{
    public class CreateDeliverymanTest : HttpServiceBase
    {
        public CreateDeliverymanTest() : base("deliveryman")
        {
        }

        [Fact]
        public async Task Must_Create_Deliveryman_StatusOk()
        {
            var deliveryman = DeliverymanMock.GetDeliveryman();

            var response = await this.Post(string.Empty, deliveryman);
            
            Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
        }
    }
}