using StackExchange.Redis;

namespace StackExchange;

public class Configuration
{
    public string String { get; set; }
    public ConfigurationOptions Options { get; set; }

    public Configuration(string configurationString)
    {
        this.String = configurationString;
        this.Options = ConfigurationOptions.Parse(this.String);
    }
}