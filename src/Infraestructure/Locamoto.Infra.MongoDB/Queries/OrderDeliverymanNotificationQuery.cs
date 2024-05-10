using Locamoto.Domain.Entities;
using Locamoto.Infra.MongoDB.Core;
using Locamoto.UseCases.Orders.Dtos;
using Locamoto.UseCases.Orders.Queries;
using MongoDB.Driver;

namespace Locamoto.Infra.MongoDB.Queries
{
    public class OrderDeliverymanNotificationQuery(string connectionString) :
        RepositoryBase<OrderDeliverymanNotification>(connectionString),
        IOrderDeliverymanNotificationQuery
    {
        public async Task<List<OrderDeliverymanNotifiedDto>> GetDeliverymanNotified()
        {
            var list = await  _dbSet.Find(_ => true).ToListAsync();

            return list.Select(p => new OrderDeliverymanNotifiedDto(
                p.CreatedAt,
                p.Deliveryman.Name,
                p.Deliveryman.DeliverymanID,
                p.Order.OrderID
            )).ToList();
        }
    }
}