using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Rentals;

namespace Locamoto.IntegrationTest.Orders
{
    public class OrderHttpService : HttpServiceBase
    {
        readonly RentalHttpService rentalHttpService = new RentalHttpService();
        public OrderHttpService() : base(ParamCoreTest.API_ORDER)
        {
        }

        public async Task CreateBackgroundForOrders()
        {
            await rentalHttpService.Create();
        }

        public async Task Create()
        {
            await rentalHttpService.Create();
        }
    }
}