using Microsoft.Extensions.Options;
using Mongodb.RestaurantStore.Datas;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;

namespace Mongodb.RestaurantStore.Services;

public class DeleteService : IDeleteService
{
    private readonly IMongoCollection<RestaurantModel> _restaurantsCollection;

    public DeleteService(
        IOptions<RestaurantStoreDataBaseSettings> restaurantStoreDatabaseSettings
    )
    {
        _restaurantsCollection =restaurantStoreDatabaseSettings.Value.Collection;
    }
    public async Task<DeleteResult> DeleteOneAsync(Guid id)
    {
        var filter = Builders<RestaurantModel>
            .Filter
            .Eq(p => p.RestaurantId, id);

        return await _restaurantsCollection.DeleteOneAsync(filter);
    }
    public async Task<DeleteResult> DeleteManyAsync(Guid id)
    {
        var filter = Builders<RestaurantModel>
            .Filter
            .Eq(p => p.RestaurantId, id);

        return await _restaurantsCollection.DeleteManyAsync(filter);
    }
}