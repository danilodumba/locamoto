using Locamoto.UseCases.CostPlans.Queries;
using Locamoto.UseCases.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;

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
        .Produces(200, typeof(List<OrderDeliverymanNotifiedDto>))
        .Produces(500, typeof(ProblemDetails))
        .WithOpenApi();
    }
}