using System.Text;
using StackExchange.Redis;

namespace StackExchange;

public class UsingARedisDatabase
{
    public string StringKey { get; set; }
    public string StringValue { get; set; }
    public byte[] BytesKey {get; set;}
    public byte[] BytesValue {get; set;}
    private readonly ConnectionMultiplexer _redis;
    private IDatabase _db;

    public UsingARedisDatabase(ConnectionMultiplexer redis)
    {
        _redis = redis;
        _db = _redis.GetDatabase();
    }

    public IDatabase GetDatabase(int databaseNumber = 0)
    {
        if (_db == null)
            _db = _redis.GetDatabase(databaseNumber);
        return _db;
    }
    public void StringSet(string strKey, string strValue)
    {

        StringKey = strKey;
        StringValue = strValue;

        _db.StringSet(StringKey, StringValue);
    }
    public string StringGet(string strKey) => _db.StringGet(StringKey);
    public void BytesSet(string strKey, string strValue)
    {

        BytesKey = Encoding.ASCII.GetBytes(strKey);
        BytesValue = Encoding.ASCII.GetBytes(StringValue);

        _db.StringSet(BytesKey, BytesValue);
    }
    public byte[] BytesGet(string strKey) => _db.StringGet(BytesValue);

}