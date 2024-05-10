using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;

public interface IOrdeDeliverymanNotificationRepository
{
    Task Create(OrderDeliverymanNotification notification);
    Task<OrderDeliverymanNotification?> GetById(Guid id);
    Task SaveChanges();
    Task<bool> HasNotificationForDeliveryman(Guid orderID, Guid deliverymanID);
}
