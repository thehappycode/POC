using Common.Helpers;
using Common.interfaces;
using Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions;

public static class CorrelationIdServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdService(this IServiceCollection services)
    {
        services.AddScoped<ICorrelationIdBase, CorrelationIdBase>();
        services.AddTransient<CorrelationIdMiddleware>();

        return services;
    }
}