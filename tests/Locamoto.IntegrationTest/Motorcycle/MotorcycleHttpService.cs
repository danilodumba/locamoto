using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Motorcycle.Mocks;

namespace Locamoto.IntegrationTest.Motorcycle
{
    public class MotorcycleHttpService : HttpServiceBase
    {
        public MotorcycleHttpService() : base("motorcycle")
        {
        }

        public async Task Create()
        {
            var motorcycle = MotorcycleMock.GetMotorcycleMock();
            await this.Post(string.Empty, motorcycle);
        }
    }
}