
namespace Locamoto.UseCases.Orders.Dtos;

public record OrderDeliverymanNotifiedDto(DateTime NotificationData, string Name, Guid DeliverymanID, Guid OrderID);
