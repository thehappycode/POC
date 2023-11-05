using Common.Constants;
using Common.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Common.Helpers;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware()
    {

    }
    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, ICorrelationIdBase correlationIdBase)
    {
        var correlationId = correlationIdBase.GetCorrelationId(context);
        AddCorrelationIdHeaderToResponse(context, correlationId);
        await _next(context);
    }

    private static void AddCorrelationIdHeaderToResponse(HttpContext context, StringValues correlationId)
    {
        context.Response.Headers.Add(CorrelationIdConstant.X_CORRELATION_ID_HEADER, new[] { correlationId.ToString() });
        // context.Response.OnStarting(() =>
        // {
        //     context.Response.Headers.Add(X_CORRELATION_ID_HEADER, correlationId.ToString());
        //     return Task.CompletedTask;
        // });
    }
}