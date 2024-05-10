using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.EF.Core;
using Microsoft.EntityFrameworkCore;

namespace Locamoto.Infra.PostgreSql.Repositories
{
    internal class MotorcycleRepository : RepositoryBase<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(LocamotoEFContext context) : base(context)
        {
        }

        public async Task<bool> ExistsPlate(string plate)
        {
            return await _dbSet.AnyAsync(x => x.Plate == plate);
        }

        public async Task<Motorcycle?> GetByPlate(string plate)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Plate == plate);
        }

        public async Task<Motorcycle?> GetMotorcycleAvailble()
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Available == true);
        }
    }
}