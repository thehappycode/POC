using MongoDB.Driver;

namespace Mongodb.Commons.Datas;

public abstract class BaseDataBaseSettings <T>
    where T : class
{
    public string ConnectionString { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string BooksCollectionName { get; set; } = null!;
    public IMongoCollection<T> Setup()
    {
        var mongoClient = new MongoClient(
            ConnectionString
        );

        var mongoDatabase = mongoClient.GetDatabase(
            DataBaseName
        );

        return mongoDatabase.GetCollection<T>(
            BooksCollectionName
        );
    }
}