using Locamoto.UseCases.CostPlans.Queries;

namespace Locamoto.WebApi.Enpoints;
public class PlanEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
       app.MapGet("/plans", async (ICostPlanServiceQuery costPlanService) =>
        {
            var costPlan = await costPlanService.GetAll();
            return costPlan;
        })
        .WithName("GetPlans")
        .WithTags("Cost Plan")
        .WithOpenApi();
    }
}