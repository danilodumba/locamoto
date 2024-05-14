using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Motorcycles.Queries;
using Locamoto.UseCases.Motorcycles.Queries.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Locamoto.WebApi.Enpoints.Motorcycle
{
    public class GetMotorcycleByPlateEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/motorcycle", async (string plate, IMotorcycleQuery motorcycleQuery) =>
        {
            var list = await motorcycleQuery.GetAllOrByPlate(plate);
            return list;
        })
        .WithName("GetByPlate")
        .WithTags("Motorcycle")
        .Produces(200, typeof(List<ListMotorcycleDto>))
        .Produces(500, typeof(ProblemDetails))
        .WithOpenApi();
        }
    }
}