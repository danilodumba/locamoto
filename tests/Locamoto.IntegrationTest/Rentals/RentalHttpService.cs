using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Deliverymans;
using Locamoto.IntegrationTest.Motorcycle;
using Locamoto.IntegrationTest.Plans;
using Locamoto.WebApi.Enpoints.Rentals.Requests;

namespace Locamoto.IntegrationTest.Rentals
{
    public class RentalHttpService: HttpServiceBase
    {
        readonly MotorcycleHttpService motorcycleHttpService = new MotorcycleHttpService();
        readonly DeliverymanHttpService deliverymanHttpService = new DeliverymanHttpService();
        readonly PlanHttpService planHttpService = new PlanHttpService();

        public RentalHttpService() : base("rental")
        {
        }

        public async Task<CreateRentRequest> GetRentRequest()
        {
             await this.motorcycleHttpService.Create();
             var deliverymanID = await this.deliverymanHttpService.Create();
             var plans = await this.planHttpService.GetPlans();

             return new CreateRentRequest(deliverymanID, plans.FirstOrDefault()?.Id ?? Guid.Empty);
        }

        public async Task Create()
        {
            var request = await this.GetRentRequest();
            await this.Post(string.Empty, request);
        }
    }
}