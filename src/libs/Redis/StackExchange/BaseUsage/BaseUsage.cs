using StackExchange.Redis;

namespace StackExchange;

public class BaseUsage
{
    public ConnectionMultiplexer Redis { get; set; }
    private const string _configurationString = "localhost:6379";
    public BaseUsage()
    {
        Redis = ConnectionMultiplexer.Connect(_configurationString);
    }
    public BaseUsage(string configurationString)
    {
        if(string.IsNullOrWhiteSpace(configurationString))
            throw new Exception("configurationString must is not empty");
        Redis = ConnectionMultiplexer.Connect(configurationString);
    }

    public BaseUsage(ConfigurationOptions configurationOptions)
    {
        Redis = ConnectionMultiplexer.Connect(configurationOptions);
    }
}