using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;

public interface IMotorcycleRepository
{
    Task Create(Motorcycle motorcycle);
    Task Update(Motorcycle motorcycle);
    Task Remove(Motorcycle motorcycle);
    Task<Motorcycle?> GetByPlate(string plate);
    Task<Motorcycle?> GetById(Guid id);
    Task<bool> ExistsPlate(string plate);
    Task<Motorcycle?> GetMotorcycleAvailble();
    Task SaveChanges();
}
