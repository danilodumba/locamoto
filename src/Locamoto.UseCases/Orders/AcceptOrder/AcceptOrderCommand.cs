using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Orders.AcceptOrder;
public record AcceptOrderCommand(Guid OrderID, Guid DeliverymanID): CommandRequest<AcceptOrderResponse>;
  
