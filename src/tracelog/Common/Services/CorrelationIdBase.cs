using Common.Constants;
using Common.interfaces;
using Microsoft.AspNetCore.Http;

namespace Common.Services;

public class CorrelationIdBase : ICorrelationIdBase
{
    private string CorrelationId { get; set; } = Guid.NewGuid().ToString();

    public string GetCorrelationId() => CorrelationId;

    public void SetCorrelationId(string correlationId) => CorrelationId = correlationId;

    public string GetCorrelationId(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue(CorrelationIdConstant.X_CORRELATION_ID_HEADER, out var correlationId))
        {
            SetCorrelationId(correlationId.ToString());
        }
        else
        {
            SetCorrelationId(Guid.NewGuid().ToString());

        }
        return GetCorrelationId();
    }

}
