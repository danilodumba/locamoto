using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.EF.Core;
using Microsoft.EntityFrameworkCore;

namespace Locamoto.Infra.PostgreSql.Repositories
{
    internal class DeliverymanRepository : RepositoryBase<Deliveryman>, IDeliverymanRepository
    {
        public DeliverymanRepository(LocamotoEFContext context) : base(context)
        {
        }

        public async Task<bool> ExistsCnh(string cnh)
        {
            return await _dbSet.AnyAsync(x => x.Cnh.Number == cnh);
        }

        public async Task<bool> ExistsCnpj(string cnpj)
        {
            return await _dbSet.AnyAsync(x => x.Cnpj.Value == cnpj);
        }
    }
}