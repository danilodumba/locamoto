using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Locamoto.IntegrationTest.Core;
using Locamoto.UseCases.CostPlans.Dtos;

namespace Locamoto.IntegrationTest.Plans
{
    public class PlanHttpService : HttpServiceBase
    {
        public PlanHttpService() : base("plans")
        {
        }

        public async Task<List<CosPlanDto>> GetPlans()
        {
            var response = await this.Get(string.Empty);
            var list = await response.Content.ReadFromJsonAsync<List<CosPlanDto>>();

            if (list is null) return new List<CosPlanDto>();

            return list;
        }
    }
}