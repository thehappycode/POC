using Common.Constants;
using Common.interfaces;
using Microsoft.AspNetCore.Http;

namespace Common.Services;

public class CorrelationIdBase : ICorrelationIdBase
{
    private string CorrelationId { get; set; } = Guid.NewGuid().ToString();

    public string GetCorrelationId() => CorrelationId;
    
    public void SetCorrelationId(string correlationId) => CorrelationId = correlationId;
}
