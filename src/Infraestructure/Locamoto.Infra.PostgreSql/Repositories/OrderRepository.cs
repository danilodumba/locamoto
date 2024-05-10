using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.EF.Core;

namespace Locamoto.Infra.PostgreSql.Repositories
{
    internal class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(LocamotoEFContext context) : base(context)
        {
        }
    }
}