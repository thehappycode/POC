using Microsoft.AspNetCore.Mvc;
using StackExchange;

namespace WebApi.Controllers.StackExchange;

[ApiController]
[Route("api/v1/StackExchange/[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly ILogger<ConfigurationController> _logger;
    private readonly string _configurationString;

    public ConfigurationController(
        IConfiguration configuration,
        ILogger<ConfigurationController> logger
    )
    {
        _logger = logger;
        _configurationString = configuration["Redis:ConfigurationString"];
    }

    [HttpGet]
    public Configuration GetConfigurationOptions(){
        var configuration = new Configuration(_configurationString);
        return configuration;
    }
}