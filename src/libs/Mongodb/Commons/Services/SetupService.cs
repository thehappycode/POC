using Microsoft.Extensions.Options;
using Mongodb.Commons.Datas;
using Mongodb.Commons.IServices;
using Mongodb.RestaurantStore.Datas;
using MongoDB.Driver;

namespace Mongodb.Commons.Services;

public class SetupService<O, T> : ISetupService<O, T>
    where O : BaseDataBaseSettings
     where T : class
{
    private readonly IOptions<O> _baseDataSettings;

    public SetupService(
        IOptions<O> baseDataSettings
    )
    {
        _baseDataSettings = baseDataSettings;
    }
    public IMongoCollection<T> Setup()
    {
        var mongoClient = new MongoClient(
            _baseDataSettings.Value.ConnectionString
        );

        var mongoDatabase = mongoClient.GetDatabase(
            _baseDataSettings.Value.DataBaseName
        );

        var restaurantsCollection = mongoDatabase.GetCollection<T>(
            _baseDataSettings.Value.BooksCollectionName
        );

        return restaurantsCollection;
    }
}