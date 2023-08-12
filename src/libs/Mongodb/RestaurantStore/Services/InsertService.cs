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
        IOptions<RestaurantStoreDataBaseSettings> restaurantStoreDatabaseSettings
    )
    {
        _restaurantsCollection = restaurantStoreDatabaseSettings.Value.Collection;
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