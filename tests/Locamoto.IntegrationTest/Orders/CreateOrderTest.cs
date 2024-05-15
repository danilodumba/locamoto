using Locamoto.IntegrationTest.Core;
using Locamoto.WebApi.Enpoints.Orders.Requests;

namespace Locamoto.IntegrationTest.Orders
{
    public class CreateOrderTest : HttpServiceBase
    {
        readonly OrderHttpService orderHttpService = new OrderHttpService();
        public CreateOrderTest() : base(ParamCoreTest.API_ORDER)
        {
        }

        [Fact]
        public async Task Must_Create_Order()
        {
            await this.orderHttpService.CreateBackgroundForOrders();
            var cost = OrderMock.GetCost();

            var response = await this.Post(string.Empty, new CreateOrderRequest(cost));

            Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
        }
    }
}