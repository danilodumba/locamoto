using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.IntegrationTest.Core;

namespace Locamoto.IntegrationTest.Orders;

public class DeliverOrderByDeliverymanTest : HttpServiceBase
{
    readonly OrderHttpService orderHttpService = new OrderHttpService();
    public DeliverOrderByDeliverymanTest() : base(ParamCoreTest.API_ORDER)
    {
    }

     [Fact]
    public async Task Must_Deliver_Order()
    {
        var order = await this.orderHttpService.Accept();

        var response = await this.Put($"{order?.OrderID}/deliveryman/{order?.DeliverymanID}/deliver");

        Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
    }
}
