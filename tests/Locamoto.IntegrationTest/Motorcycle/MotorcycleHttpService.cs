using System.Net.Http.Json;
using Locamoto.IntegrationTest.Core;
using Locamoto.IntegrationTest.Motorcycle.Mocks;

namespace Locamoto.IntegrationTest.Motorcycle
{
    public class MotorcycleHttpService : HttpServiceBase
    {
        public MotorcycleHttpService() : base(ParamCoreTest.API_MOTORCYCLE)
        {
        }

        public async Task<Guid> Create()
        {
            var motorcycle = MotorcycleMock.GetMotorcycleMock();
            var response = await this.Post(string.Empty, motorcycle);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }
    }
}