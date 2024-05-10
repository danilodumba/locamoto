using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;

public interface IOrderNotificationRepository
{
    Task Create(OrderNotification notification);
    Task<OrderNotification?> GetById(Guid id);
    Task SaveChanges();
    Task<bool> HasNotificationForDeliveryman(Guid orderID, Guid deliverymanID);
}
