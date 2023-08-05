using Microsoft.AspNetCore.Mvc;
using StackExchange;
using StackExchange.Redis;

namespace WebApi.Controllers.StackExchange;


[ApiController]
[Route("api/v1/StackExchange/[controller]")]
public class BaseUsageController : ControllerBase
{
    private readonly ILogger<BaseUsageController> _logger;
    private readonly string _configurationString;
    public BaseUsageController(
        IConfiguration configuration,
        ILogger<BaseUsageController> logger
    )
    {
        _logger = logger;
        _configurationString = configuration["Redis:ConfigurationStringSentinel"];
        Console.WriteLine(_configurationString);
    }
    [HttpGet]
    public List<dynamic> Get()
    {
        var results = new List<dynamic>();
        var baseUsage = new BaseUsage();
        var usingARedisDatabase = new UsingARedisDatabase(baseUsage.Redis);

        var strKey = "myStringKey";
        var strValue = "my String Value";
        usingARedisDatabase.StringSet(strKey, strValue);
        results.Add(usingARedisDatabase.StringGet(strKey));

        var bytesKey = "myBytesKey";
        var bytesValue = "my Bytes Value";
        usingARedisDatabase.StringSet(bytesKey, bytesValue);
        results.Add(usingARedisDatabase.StringGet(bytesKey));

        return results;
    }

    [HttpGet("PubSub")]
    public bool PubSub(string message, string content)
    {
        try
        {
            var baseUsage = new BaseUsage();
            var usingRedisPubSub = new UsingRedisPubSub(baseUsage.Redis);
            usingRedisPubSub.Publisher(message, content);
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }

    [HttpGet("EndPoints")]
    public System.Net.EndPoint[] GetEndpoints()
    {
        var baseUsage = new BaseUsage();
        var server = new AccessingIndividualServers(baseUsage.Redis);
        return server.GetEndPoints();
    }

    [HttpGet("GetClientInfos")]
    public ClientInfo[] GetClientInfos()
    {
        var baseUsage = new BaseUsage();
        var server = new AccessingIndividualServers(baseUsage.Redis);
        return server.GetClientInfos();
    }

    [HttpGet("GetLastSave")]
    public DateTime GetLastSave()
    {
        var baseUsage = new BaseUsage();
        var server = new AccessingIndividualServers(baseUsage.Redis);
        return server.GetLastSave();
    }

    [HttpPost("SetKey")]
    public string SetKey([FromBody] KeyValue keyValue)
    {
        var sentinelConfig = new ConfigurationOptions();
        sentinelConfig.ServiceName = "mymaster";
        sentinelConfig.EndPoints.Add("172.18.0.5",26379);
        sentinelConfig.EndPoints.Add("172.18.0.6",26380);
        sentinelConfig.EndPoints.Add("172.18.0.7",26381);
        sentinelConfig.TieBreaker = "";
        // sentinelConfig.DefaultVersion = new Version(4, 0, 11);
        // is importal to set the Sentinel commands supported
        sentinelConfig.CommandMap = CommandMap.Sentinel;
        
        // get sentinel connection
        var sentinelConnection = ConnectionMultiplexer.Connect(sentinelConfig, Console.Out);

        // create master service configuration
        var masterConfig = new ConfigurationOptions{
            ServiceName = "mymaster",
            // AllowAdmin = true,
            // AbortOnConnectFail = false
        };

        // get master Redis connection
        var masterConnection = sentinelConnection.GetSentinelMasterConnection(masterConfig);

        // get a connection to the master
        // var redisServiceOptions = new ConfigurationOptions();
        // redisServiceOptions.ServiceName = "mymaster";
        // redisServiceOptions.AbortOnConnectFail = false;
        // redisServiceOptions.AllowAdmin = true;

        // var masterConnection = sentinelConnection.GetSentinelMasterConnection(redisServiceOptions);

        var db = masterConnection.GetDatabase();
        db.StringSet(keyValue.Key, keyValue.Value);

        var result = db.StringGet(keyValue.Key);

        return result;
        // var baseUsage = new BaseUsage(_configurationString);
        // var usingARedisDatabase = new UsingARedisDatabase(baseUsage.Redis);
        // usingARedisDatabase.StringSet(keyValue.Key, keyValue.Value);
        // return usingARedisDatabase.StringGet(keyValue.Key);
    }
}