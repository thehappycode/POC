using Common.Constants;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace Source.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly HttpClientDentinationService _httpClientDentinationService;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        HttpClientDentinationService httpClientDentinationService
    )
    {
        _logger = logger;
        _httpClientDentinationService = httpClientDentinationService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        Log.Information("Source/GetWeatherForecast");
        var correlationId = HttpContext.Request.Headers[CorrelationIdConstant.X_CORRELATION_ID_HEADER];
        Log.Information($"X-Correlation-Id = {correlationId}");

        try
        {
            var response = await _httpClientDentinationService.GetAPI("WeatherForecast");
            if (response.IsSuccessStatusCode){
                var contentString = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Call HttpClient: {JsonConvert.SerializeObject(contentString)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message, ex.StackTrace, ex.InnerException);
        }

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
