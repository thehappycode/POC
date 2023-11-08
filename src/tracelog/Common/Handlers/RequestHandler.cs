using Common.Constants;
using Common.interfaces;
using Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Common.Handlers;

public class RequestHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string? _correlationId;

    public RequestHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(CorrelationIdConstant.X_CORRELATION_ID_HEADER, out var correlationId))
            _correlationId = correlationId.ToString();
    }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        request.Headers.Add(CorrelationIdConstant.X_CORRELATION_ID_HEADER, _correlationId);
        return base.SendAsync(request, cancellationToken);
    }
}