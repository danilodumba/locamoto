using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Rentals;

namespace Locamoto.IntegrationTest.Orders
{
    public class OrderHttpService : HttpServiceBase
    {
        readonly RentalHttpService rentalHttpService = new RentalHttpService();
        public OrderHttpService() : base("order")
        {
        }

        public async Task CreateBackgroundForOrders()
        {
            await rentalHttpService.Create();
        }
    }
}