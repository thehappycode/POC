using Microsoft.AspNetCore.Http;

namespace Common.interfaces;

public interface ICorrelationIdBase
{
    string GetCorrelationId();
    void SetCorrelationId(string correlationId);
}