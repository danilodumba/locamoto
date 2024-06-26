using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Deliverymans;
using Locamoto.IntegrationTest.Motorcycle;
using Locamoto.IntegrationTest.Plans;
using Locamoto.UseCases.Rentals.Create;
using Locamoto.WebApi.Enpoints.Rentals.Requests;
using MassTransit;

namespace Locamoto.IntegrationTest.Rentals
{
    public class RentalHttpService: HttpServiceBase
    {
        readonly MotorcycleHttpService motorcycleHttpService = new MotorcycleHttpService();
        readonly DeliverymanHttpService deliverymanHttpService = new DeliverymanHttpService();
        readonly PlanHttpService planHttpService = new PlanHttpService();

        public RentalHttpService() : base(ParamCoreTest.API_RENT)
        {
        }

        public async Task<CreateRentRequest> GetRentRequest()
        {
             await this.motorcycleHttpService.Create();
             var deliverymanID = await this.deliverymanHttpService.Create();
             var plans = await this.planHttpService.GetPlans();

             return new CreateRentRequest(deliverymanID, plans.FirstOrDefault()?.Id ?? Guid.Empty);
        }

        public async Task<CreateRentCommandResponse> Create()
        {
            var request = await this.GetRentRequest();
            var response = await this.Post(string.Empty, request);

            return await response.Content.ReadFromJsonAsync<CreateRentCommandResponse>() ?? new CreateRentCommandResponse();
        }
    }
}