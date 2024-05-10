using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Motorcycles.Queries;
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
        .WithOpenApi();
        }
    }
}