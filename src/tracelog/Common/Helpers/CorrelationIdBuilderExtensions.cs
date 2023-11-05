using Microsoft.AspNetCore.Builder;

namespace Common.Helpers;

public static class CorrelationIdBuilderExtensions
{
    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder builder){
        builder.UseMiddleware<CorrelationIdMiddleware>();
        
        return builder;
    }
}