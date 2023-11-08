using Common.Constants;
using Common.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Common.Helpers;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ICorrelationIdBase _correlationIdBase;
    public CorrelationIdMiddleware()
    {

    }
    public CorrelationIdMiddleware(RequestDelegate next, ICorrelationIdBase correlationIdBase)
    {
        _next = next;
        _correlationIdBase = correlationIdBase;
    }

    public async Task Invoke(HttpContext context)
    {
        // request
        if (context.Request.Headers.TryGetValue(CorrelationIdConstant.X_CORRELATION_ID_HEADER, out var correlationIdRequest))
        {
            _correlationIdBase.SetCorrelationId(correlationIdRequest.ToString());
        }
        else
        {
            _correlationIdBase.SetCorrelationId(Guid.NewGuid().ToString());
            context.Request.Headers.Add(CorrelationIdConstant.X_CORRELATION_ID_HEADER, new[] { _correlationIdBase.GetCorrelationId() });
        }

        // response
        if (context.Response.Headers.TryGetValue(CorrelationIdConstant.X_CORRELATION_ID_HEADER, out var correlationIdResponse))
        {
            if (correlationIdRequest != correlationIdResponse)
            {
                context.Response.Headers[CorrelationIdConstant.X_CORRELATION_ID_HEADER] = _correlationIdBase.GetCorrelationId();
            }
        }
        else
        {
            context.Response.Headers.Add(CorrelationIdConstant.X_CORRELATION_ID_HEADER, new[] { _correlationIdBase.GetCorrelationId() });
        }

        await _next(context);
    }
}