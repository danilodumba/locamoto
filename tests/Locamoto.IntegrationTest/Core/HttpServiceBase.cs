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
        protected HttpServiceBase(string api)
        {
            _api = api;
            _client = HttpClientService.GetClient();
        }

        protected async Task<HttpResponseMessage> Get(string path)
        {
            var api = _api +"/"+ path;
            return await _client.GetAsync(api);
        }

        protected async Task<HttpResponseMessage> Post(string path, object objectJson)
        {
            var api = _api + "/" + path;
            var json =  JsonConvert.SerializeObject(objectJson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(api, content);
        }

        protected async Task<HttpResponseMessage> Remove(string path)
        {
            var api = _api + "/" + path;
            return await _client.DeleteAsync(api);
        }

        protected async Task<HttpResponseMessage> Post(string api, string path, object objectJson)
        {
            api = api + "/" + path;
            var json = JsonConvert.SerializeObject(objectJson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(api, content);
        }

        protected async Task<HttpResponseMessage> Put(string path, object objectJson)
        {
            var api = _api + "/" + path;
            var json = JsonConvert.SerializeObject(objectJson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PutAsync(api, content);
        }

        protected async Task<HttpResponseMessage> Put(string path)
        {
            var api = _api + "/" + path;
            return await _client.PutAsync(api, null);
        }

        protected async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent)!;
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }
    }