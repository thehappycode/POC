using MongoDB.Driver;

namespace Mongodb.Commons.Datas;

public abstract class BaseStoreDataBaseSettings<T>
    where T : class
{
    public string ConnectionString { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
    private IMongoCollection<T> _Collection { get; set; } = null!;

    public IMongoCollection<T> Collection => _Collection is not null
        ? _Collection
        : GetCollection();

    public IMongoCollection<T> GetCollection()
    {
        var mongoClient = new MongoClient(
            ConnectionString
        );

        var mongoDatabase = mongoClient.GetDatabase(
            DataBaseName
        );

        _Collection = mongoDatabase.GetCollection<T>(
            CollectionName
        );

        return _Collection;
    }
}