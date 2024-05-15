using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Rentals;

namespace Locamoto.IntegrationTest.Motorcycle
{
    public class RemoveMotorcycleTest: HttpServiceBase
    {
        MotorcycleHttpService motorcycleHttpService = new MotorcycleHttpService();
        RentalHttpService rentalHttpService = new RentalHttpService();
        public RemoveMotorcycleTest() : base(ParamCoreTest.API_MOTORCYCLE)
        {
        }

        [Fact]
        public async Task Must_Remove_Motorcycle()
        {
            var motorcycleID = await motorcycleHttpService.Create();
            var response = await this.Remove(motorcycleID.ToString());

            Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
        }

        [Fact]
        public async Task Must_Validate_Remove_Motorcycle_Rent()
        {
            var rent = await rentalHttpService.Create();
            var response = await this.Remove(rent.Motorcycle.MotorcycleID.ToString());

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest, $"Response invalid. StatusCode: {response.StatusCode} ");
        }
    }
}