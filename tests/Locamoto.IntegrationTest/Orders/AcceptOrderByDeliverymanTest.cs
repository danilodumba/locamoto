using System.Net.Http.Json;
using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Rentals;
using Locamoto.UseCases.Orders.Create;
using Locamoto.WebApi.Enpoints.Orders.Requests;

namespace Locamoto.IntegrationTest.Orders
{
    public class AcceptOrderByDeliverymanTest : HttpServiceBase
    {
        RentalHttpService rentalHttpService = new RentalHttpService();
        public AcceptOrderByDeliverymanTest() : base(ParamCoreTest.API_ORDER)
        {
        }

        [Fact]
        public async Task Must_Accept_Order()
        {
            var rent = await rentalHttpService.Create();
            var cost = OrderMock.GetCost();
            var responseOrder = await this.Post(string.Empty, new CreateOrderRequest(cost));
            var order = await responseOrder.Content.ReadFromJsonAsync<CreateOrderResponse>();

            Thread.Sleep(3000); //Pausa para dar tempo da mensageria.

            var response = await this.Put($"{order?.OrderID}/deliveryman/{rent.Deliveryman.DeliverymanID}/accept");

             Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
        }

        [Fact]
        public async Task Must_Accept_Order_Invalid()
        {
            var rent = await rentalHttpService.Create();

            var response = await this.Put($"{Guid.NewGuid()}/deliveryman/{rent.Deliveryman.DeliverymanID}/accept");

             Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest, $"Response invalid. StatusCode: {response.StatusCode} ");
        }

        [Fact]
        public async Task Must_Accept_Deliveryman_Invalid()
        {
            var cost = OrderMock.GetCost();
            var responseOrder = await this.Post(string.Empty, new CreateOrderRequest(cost));
            var order = await responseOrder.Content.ReadFromJsonAsync<CreateOrderResponse>();

            var response = await this.Put($"{order?.OrderID}/deliveryman/{Guid.NewGuid()}/accept");

             Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest, $"Response invalid. StatusCode: {response.StatusCode} ");
        }
    }
}