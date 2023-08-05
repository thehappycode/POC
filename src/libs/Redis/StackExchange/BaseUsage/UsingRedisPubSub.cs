using StackExchange.Redis;

namespace StackExchange;

public class UsingRedisPubSub
{
    private readonly ConnectionMultiplexer _redis;
    private ISubscriber _sub;

    public UsingRedisPubSub(ConnectionMultiplexer redis)
    {
        _redis = redis;
        _sub = _redis.GetSubscriber();
        Subscriber();
    }

    public void Publisher(string messages, string content) => _sub.Publish(messages, content);

    public void Subscriber(){
        var channel1 = "v1/messages";
        _sub.Subscribe(channel1, (channel, message) => {
            Console.WriteLine($"{channel1}: {channel.ToString()}-{(string)message}");
        });

        // ChannelMessageQueue
        var channel2 = "v2/messages";
        _sub.Subscribe(channel2).OnMessage(channelMessage => {
            Console.WriteLine($"{channel2}: {channelMessage.Channel.ToString()}-{(string)channelMessage.Message}");
        });
    }
}