using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.Domain.Entities
{
    public class OrderNotification
    {
        public OrderNotification(Guid orderID, Guid deliverymanID, DateTime createdAt)
        {
            OrderID = orderID;
            DeliverymanID = deliverymanID;
            CreatedAt = createdAt;
        }

        public Guid OrderID { get; set; }
        public Guid DeliverymanID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}