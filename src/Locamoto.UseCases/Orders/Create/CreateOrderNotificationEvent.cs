using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Locamoto.UseCases.Orders.Create
{
    public record CreateOrderNotificationEvent(Guid OrderID, decimal Cost, DateTime CreatedAt): INotification;
}