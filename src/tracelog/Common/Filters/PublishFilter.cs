using Common.Constants;
using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Common.Filters;

public class PublishFilter<TMessage> : IFilter<PublishContext<TMessage>>
    where TMessage : class
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PublishFilter(
        IHttpContextAccessor httpContextAccessor
    )
    {
        Console.WriteLine("Contructor PublishFilter");
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task Send(PublishContext<TMessage> context, IPipe<PublishContext<TMessage>> next)
    {
        // Log.Information("PublishFilter Send");
        Console.WriteLine("PublishFilter Send");
        var correlationId = _httpContextAccessor.HttpContext.Request.Headers[CorrelationIdConstant.X_CORRELATION_ID_HEADER];
        context.CorrelationId = Guid.Parse(correlationId);
        await next.Send(context);
    }

    public void Probe(ProbeContext context)
    {
        Console.WriteLine("PublishFilter Probe");
    }
}