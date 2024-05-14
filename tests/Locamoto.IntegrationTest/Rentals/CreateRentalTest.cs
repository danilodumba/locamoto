using Locamoto.IntegrationTest.Core;

namespace Locamoto.IntegrationTest.Rentals
{
    public class CreateRentalTest: HttpServiceBase
    {
        readonly RentalHttpService rentalHttpService = new RentalHttpService();
        public CreateRentalTest() : base("rent")
        {
        }
        
        [Fact]
        public async Task Must_Create_Rental_StatusOk()
        {
            var rent = await rentalHttpService.GetRentRequest();
            var response = await this.Post(string.Empty, rent);

            Assert.True(response.IsSuccessStatusCode, $"Response invalid. StatusCode: {response.StatusCode} ");
        }
    }
}