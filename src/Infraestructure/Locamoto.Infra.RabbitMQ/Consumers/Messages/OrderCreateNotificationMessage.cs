using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.Infra.RabbitMQ.Consumers.Messages
{
    public class OrderCreateNotificationMessage
    {
        public Guid OrderID { get; set; }
        public DateTime CreatedDate { get; set;}
        public decimal Cost { get; set; }
    }
}