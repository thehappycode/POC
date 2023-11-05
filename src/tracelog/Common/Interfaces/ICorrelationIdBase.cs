using Microsoft.AspNetCore.Http;

namespace Common.interfaces;

public interface ICorrelationIdBase
{
    string GetCorrelationId();
    string GetCorrelationId(HttpContext context);
    void SetCorrelationId(string correlationId);
}