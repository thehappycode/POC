using System.Net;
using StackExchange.Redis;

namespace StackExchange;

public class AccessingIndividualServers
{
    private readonly ConnectionMultiplexer _redis;
    private IServer _server;

    public AccessingIndividualServers(ConnectionMultiplexer redis)
    {
        _redis = redis;
        _server = _redis.GetServer("localhost", 6379);
    }

    public EndPoint[] GetEndPoints() => _redis.GetEndPoints();

    public ClientInfo[] GetClientInfos() => _server.ClientList();

    public DateTime GetLastSave() => _server.LastSave();

}