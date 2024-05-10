using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;

namespace Locamoto.Infra.MongoDB.Repositories;
public class OrderDeliverymanNotificationRepository : IOrdeDeliverymanNotificationRepository
{
    public Task Create(OrderDeliverymanNotification notification)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDeliverymanNotification?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasNotificationForDeliveryman(Guid orderID, Guid deliverymanID)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}
