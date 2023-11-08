using Common.Handlers;
using Common.Helpers;
using Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions;

public static class HttpClientServiceCollectionExtensions
{
    public static IServiceCollection AddHttpClientService(this IServiceCollection services)
    {
        services.AddTransient<RequestHandler>();
        services.AddHttpClient<HttpClientDentinationService>()
            .AddHttpMessageHandler<RequestHandler>();

        // services.AddHttpClient<HttpClientDentinationService>(httpClient => { // Change uri
        //     httpClient.BaseAddress = new Uri("")
        // });
        return services;
    }
}