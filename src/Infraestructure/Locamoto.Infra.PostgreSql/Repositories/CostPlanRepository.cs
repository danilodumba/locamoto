using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.EF.Core;

namespace Locamoto.Infra.PostgreSql.Repositories
{
    internal class CostPlanRepository: RepositoryBase<CostPlan>, ICostPlanRepository
    {
        public CostPlanRepository(LocamotoEFContext context) : base(context)
        {
        }
    }
}