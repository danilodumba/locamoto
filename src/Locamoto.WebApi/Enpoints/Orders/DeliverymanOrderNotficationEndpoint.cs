namespace Locamoto.WebApi.Enpoints.Orders;

public class DeliverymanOrderNotficationEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/order/deliveryman-notification", (
            CancellationToken cancellationToken
            ) =>
        {
            return Results.Ok("Não implementado.");
        })
        .WithName("DeliverymanNotifications")
        .WithTags("Orders")
        .WithOpenApi();
    }
}
