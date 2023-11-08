using System.Net.Http.Headers;
using Common.Constants;
using Common.interfaces;

namespace Common.Services;

public class HttpClientDentinationService
{
    private readonly HttpClient _httpClient;
    public HttpClientDentinationService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(HttpClientConstanct.URI_DENTINATION);
        _httpClient.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
    }

    public async Task<HttpResponseMessage> GetAPI(string requestUri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var response = await _httpClient.SendAsync(request);

        return response;
    }
}