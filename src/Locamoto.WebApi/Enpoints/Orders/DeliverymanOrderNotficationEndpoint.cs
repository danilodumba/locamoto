using Locamoto.UseCases.Orders.Queries;

namespace Locamoto.WebApi.Enpoints.Orders;

public class DeliverymanOrderNotficationEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/order/deliveryman-notified", async (
            IOrderDeliverymanNotificationQuery serviceQuery,
            CancellationToken cancellationToken
            ) =>
        {
            var list = await serviceQuery.GetDeliverymanNotified();
            return Results.Ok(list);
        })
        .WithName("DeliverymanNotifications")
        .WithTags("Orders")
        .WithOpenApi();
    }
}
