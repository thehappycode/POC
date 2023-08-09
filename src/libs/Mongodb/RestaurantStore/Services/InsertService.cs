using Microsoft.Extensions.Options;
using Mongodb.RestaurantStore.Datas;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;

namespace Mongodb.RestaurantStore.Services;

public class InsertServcie : IInsertServcie
{
    private readonly IMongoCollection<RestaurantModel> _restaurantsCollection;

    public InsertServcie(
         IOptions<RestaurantDataSettings> restaurantDataSettings
    )
    {
         var mongoClient = new MongoClient(
            restaurantDataSettings.Value.ConnectionString
        );

        var mongoDatabase = mongoClient.GetDatabase(
            restaurantDataSettings.Value.DataBaseName
        );

        _restaurantsCollection = mongoDatabase.GetCollection<RestaurantModel>(
            restaurantDataSettings.Value.BooksCollectionName
        );
    }
    public async Task InsertOneAsync(RestaurantModel restaurantModel)
    {
        await _restaurantsCollection.InsertOneAsync(restaurantModel);
    }
    public async Task InsertManyAsync(IEnumerable<RestaurantModel> restaurantModels)
    {
        await _restaurantsCollection.InsertManyAsync(restaurantModels);
    }

}