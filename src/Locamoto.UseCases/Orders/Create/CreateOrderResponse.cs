using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Orders.Create;

public record CreateOrderResponse: CommandResponse
{
    public Guid OrderID {get; set;}
}
  
