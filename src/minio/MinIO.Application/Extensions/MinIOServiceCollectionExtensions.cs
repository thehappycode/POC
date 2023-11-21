using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using minio.Options;
using Minio;
using Newtonsoft.Json;

namespace MiniIO.Applcation.Extensions;

public static class MinIOServiceCollectionExtensions
{
    public static IServiceCollection AddMinIO(this IServiceCollection services, IConfiguration configuration)
    {
        var minIOOptions = configuration
            .GetSection(nameof(MinIOOptions))
            .Get<MinIOOptions>();
        Console.WriteLine($"minIOOpitons: {JsonConvert.SerializeObject(minIOOptions)}");

        services.AddMinio(configure => configure
            .WithEndpoint(minIOOptions.Endpoint)
            .WithCredentials(minIOOptions.AccessKey, minIOOptions.SecretKey)
            .WithSSL(minIOOptions.Secure)
        );

        return services;
    }
}