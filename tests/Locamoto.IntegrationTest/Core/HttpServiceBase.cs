using System.Text;
using Locamoto.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Locamoto.IntegrationTest.Core;

public abstract class HttpServiceBase: IDisposable
{
        protected readonly HttpClient _client;
        private readonly string _api;
        const string ENVIRONMENT = "Development";
        protected HttpServiceBase(string api)
        {
            _api = api;
            if (_client != null) return;

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{ENVIRONMENT}.json", optional: true)
                .AddEnvironmentVariables(ENVIRONMENT);
                
            var factory = new WebApplicationFactory<IAssemblyMaker>()
                .WithWebHostBuilder(builder => {
                    builder.UseEnvironment(ENVIRONMENT);
                    builder.UseConfiguration(configurationBuilder.Build());

                    builder.ConfigureServices(services =>
                    {
                        //services.AddSingleton<IAccountService, AccountServiceMock>();
                    });
                });

            _client = factory.CreateClient();
        }

        protected async Task<HttpResponseMessage> Get(string caminho)
        {
            var api = _api +"/"+ caminho;
            return await _client.GetAsync(api);
        }

        protected async Task<HttpResponseMessage> Post(string caminho, object objetoJson)
        {
            var api = _api + "/" + caminho;
            var json =  JsonConvert.SerializeObject(objetoJson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(api, content);
        }

        protected async Task<HttpResponseMessage> Post(string api, string caminho, object objetoJson)
        {
            api = api + "/" + caminho;
            var json = JsonConvert.SerializeObject(objetoJson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(api, content);
        }

        protected async Task<HttpResponseMessage> Put(string caminho, object objetoJson)
        {
            var api = _api + "/" + caminho;
            var json = JsonConvert.SerializeObject(objetoJson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PutAsync(api, content);
        }

        protected async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }
    }