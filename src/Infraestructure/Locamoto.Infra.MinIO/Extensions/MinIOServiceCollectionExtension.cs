using Locamoto.UseCases.DeliveryDrivers.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace Locamoto.Infra.MinIO.Extensions;

public static class MinIOServiceCollectionExtension
{
    public static void AddInfraMinIO(this IServiceCollection services, IConfiguration configuration)
    {
        var accessKey = configuration.GetSection("MinIO")["AccessKey"];
        var secretKey = configuration.GetSection("MinIO")["SecretKey"];
        var endpoint = configuration.GetSection("MinIO")["Endpoint"];

    
        services.AddScoped(_ => new MinioClient(endpoint, accessKey, secretKey));
        services.AddScoped<IStorageCnhService, StorageCnhService>();
    }
}
