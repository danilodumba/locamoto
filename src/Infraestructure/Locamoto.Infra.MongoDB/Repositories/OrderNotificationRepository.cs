using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.MongoDB.Core;
using MongoDB.Driver;

namespace Locamoto.Infra.MongoDB.Repositories;
public class OrderDeliverymanNotificationRepository(string connectionString) :
    RepositoryBase<OrderDeliverymanNotification>(connectionString),
    IOrdeDeliverymanNotificationRepository
{
    public async Task Create(OrderDeliverymanNotification notification)
    {
       await _dbSet.InsertOneAsync(notification);
    }

    public async Task<OrderDeliverymanNotification?> GetById(Guid id)
    {
        return await _dbSet.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> HasNotificationForDeliveryman(Guid orderID, Guid deliverymanID)
    {
        return await _dbSet.Find(x => x.Order.OrderID == orderID 
                             && x.Deliveryman.DeliverymanID == deliverymanID)
                     .AnyAsync();
    }
}
