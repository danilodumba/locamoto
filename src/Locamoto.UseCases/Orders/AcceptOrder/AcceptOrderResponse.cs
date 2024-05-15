using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.Orders.AcceptOrder;

public record AcceptOrderResponse: CommandResponse
{
    public Guid OrderID { get; set; }
    public decimal Cost { get; set; }
    public Guid DeliverymanID { get; set; }
    public string Deliveryman { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }    
}
  
