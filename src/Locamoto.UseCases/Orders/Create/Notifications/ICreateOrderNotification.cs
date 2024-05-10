using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.UseCases.Orders.Create.Notifications
{
    public interface ICreateOrderNotification
    {
        Task Send(CreateOrderMessage message);
    }
}