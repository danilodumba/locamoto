
namespace Locamoto.Domain.Entities
{
    public class OrderDeliverymanNotification(OrderNotification order, DeliverymanNotification deliveryman)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public OrderNotification Order { get; set; } = order;
        public DeliverymanNotification Deliveryman { get; set; } = deliveryman;
    }

    public class DeliverymanNotification(Guid deliverymanID, string name)
    {
        public Guid DeliverymanID { get; set; } = deliverymanID;
        public string Name { get; set; } = name;
    }

    public class OrderNotification(Guid orderID, decimal cost, DateTime data)
    {
        public Guid OrderID { get; set; } = orderID;
        public decimal Cost { get; set; } = cost;
        public DateTime Data { get; set; } = data;
    }
}