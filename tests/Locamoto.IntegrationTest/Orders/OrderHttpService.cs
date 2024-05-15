using System.Net.Http.Json;
using Locamoto.Domain.Entities;
using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Rentals;
using Locamoto.UseCases.Orders.AcceptOrder;
using Locamoto.UseCases.Orders.Create;
using Locamoto.WebApi.Enpoints.Orders.Requests;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Locamoto.IntegrationTest.Orders
{
    public class OrderHttpService : HttpServiceBase
    {
        readonly RentalHttpService rentalHttpService = new RentalHttpService();
        public OrderHttpService() : base(ParamCoreTest.API_ORDER)
        {
        }

        public async Task CreateBackgroundForOrders()
        {
            await rentalHttpService.Create();
        }

        public async Task<CreateOrderResponse?> Create()
        {
            await rentalHttpService.Create();
            var cost = OrderMock.GetCost();
            var responseOrder = await this.Post(string.Empty, new CreateOrderRequest(cost));
            return await responseOrder.Content.ReadFromJsonAsync<CreateOrderResponse>();
        }

        public async Task<AcceptOrderResponse?> Accept()
        {
            var rent = await rentalHttpService.Create();
            var cost = OrderMock.GetCost();
            var responseOrder = await this.Post(string.Empty, new CreateOrderRequest(cost));
            var order = await responseOrder.Content.ReadFromJsonAsync<CreateOrderResponse>();

            Thread.Sleep(3000);

            var response = await this.Put($"{order?.OrderID}/deliveryman/{rent.Deliveryman.DeliverymanID}/accept");

            return await response.Content.ReadFromJsonAsync<AcceptOrderResponse>();
        } 
    }
}