using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;

public interface IDeliverymanRepository
{
    Task Create(Deliveryman deliveryman);
    Task Update(Deliveryman deliveryman);
    Task<Deliveryman?> GetById(Guid id);
    Task SaveChanges();
    Task<bool> ExistsCnpj(string cnpj);
    Task<bool> ExistsCnh(string cnh);
}
