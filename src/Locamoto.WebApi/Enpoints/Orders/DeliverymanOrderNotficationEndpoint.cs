using Locamoto.UseCases.Orders.Dtos;
using Locamoto.UseCases.Orders.Queries;
using Microsoft.AspNetCore.Mvc;

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
        .Produces(200, typeof(List<OrderDeliverymanNotifiedDto>))
        .Produces(500, typeof(ProblemDetails))
        .WithOpenApi();
    }
}
