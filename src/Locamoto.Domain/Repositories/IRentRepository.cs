using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;
public interface IRentRepository
{
    Task<bool> ExistsRentForMotorcycle(Guid motorcycleID);
    Task Create(Rent rent);
    Task Update(Rent rent);
    Task<Rent?> GetById(Guid id);
    Task<Rent?> GetByMotorcyclePlate(string plate);
    Task SaveChanges();
}
