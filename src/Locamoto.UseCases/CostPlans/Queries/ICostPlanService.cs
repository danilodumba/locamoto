using Locamoto.UseCases.CostPlans.Dtos;

namespace Locamoto.UseCases.CostPlans.Queries;
public interface ICostPlanServiceQuery
{
    Task<List<CosPlanDto>> GetAll();
}
