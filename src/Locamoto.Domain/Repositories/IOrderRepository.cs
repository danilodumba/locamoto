using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;

public interface IOrderRepository
{
    Task Create(Order order);
    Task Update(Order order);
    Task<Order?> GetById(Guid id);
    Task SaveChanges();
}
