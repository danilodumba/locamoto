using Locamoto.Domain.Entities;

namespace Locamoto.Domain.Repositories;

public interface ICostPlanRepository
{
    Task<CostPlan?> GetById(Guid id);
}
