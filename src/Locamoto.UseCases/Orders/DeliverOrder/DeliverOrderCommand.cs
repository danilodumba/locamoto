using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Orders.DeliverOrder;
public record DeliverOrderCommand(Guid OrderID, Guid DeliverymanID): CommandRequest<DeliverOrderResponse>;
  
