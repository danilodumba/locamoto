using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Locamoto.IntegrationTest.Core
{
    public static class HttpClientService
    {
        private static HttpClient? _client;
        const string ENVIRONMENT = "Development";
        public static HttpClient GetClient()
        {
            if (_client != null) return _client;

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

            return factory.CreateClient();
        }
    }
}