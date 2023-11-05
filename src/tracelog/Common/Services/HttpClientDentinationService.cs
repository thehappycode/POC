using System.Net.Http.Headers;
using Common.Constants;
using Common.interfaces;

namespace Common.Services;

public class HttpClientDentinationService
{
    // private const string URI = "http://localhost:5263/";
    private readonly HttpClient _httpClient;
    private readonly ICorrelationIdBase _correlationIdBase;

    public HttpClientDentinationService(HttpClient httpClient, ICorrelationIdBase correlationIdBase)
    {
        _httpClient = httpClient;
        _correlationIdBase = correlationIdBase;

        _httpClient.BaseAddress = new Uri(HttpClientConstanct.URI_DENTINATION);
        _httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header

        var correlationId = _correlationIdBase.GetCorrelationId();
        Console.WriteLine($"HttpClientDentinationService: {correlationId}");
        _httpClient.DefaultRequestHeaders.Add(CorrelationIdConstant.X_CORRELATION_ID_HEADER, correlationId);;
    }

    public async Task<HttpResponseMessage> GetAPI(string requestUri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var response = await _httpClient.SendAsync(request);

        return response;
    }
}