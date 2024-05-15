using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.EF.Core;
using Microsoft.EntityFrameworkCore;

namespace Locamoto.Infra.PostgreSql.Repositories;
internal class OrderRepository: RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(LocamotoEFContext context) : base(context)
    {
    }

    public override async Task<Order?> GetById(Guid id)
    {
        return await _dbSet
                        .Include(x => x.Deliveryman)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }
}
