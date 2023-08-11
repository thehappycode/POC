using MongoDB.Driver;

namespace Mongodb.Commons.Datas;

public abstract class BaseDataBaseSettings<T>
    where T : class
{
    private string ConnectionString { get; set; } = null!;
    private string DataBaseName { get; set; } = null!;
    private string CollectionName { get; set; } = null!;

    public IMongoCollection<T> Collection { get; set; } = null!;

    public IMongoCollection<T> GetCollection()
    {
        if (Collection is null)
        {

            var mongoClient = new MongoClient(
                ConnectionString
            );

            var mongoDatabase = mongoClient.GetDatabase(
                DataBaseName
            );

            Collection = mongoDatabase.GetCollection<T>(
                CollectionName
            );
        }

        return Collection;
    }
}