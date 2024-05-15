using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Locamoto.IntegrationTest.Core;

namespace Locamoto.IntegrationTest.Deliverymans
{
    public class DeliverymanHttpService: HttpServiceBase
    {
        public DeliverymanHttpService() : base(ParamCoreTest.API_DELIVERYMAN)
        {
        }

        public async Task<Guid> Create()
        {
            var motorcycle = DeliverymanMock.GetDeliveryman();
            var response = await this.Post(string.Empty, motorcycle);

            return await response.Content.ReadFromJsonAsync<Guid>();
        }
    }
}