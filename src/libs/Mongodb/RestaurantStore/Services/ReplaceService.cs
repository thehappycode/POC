using Mongodb.Commons.IServices;
using Mongodb.RestaurantStore.Datas;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;

namespace Mongodb.RestaurantStore.Services;

public class ReplaceService : IReplaceService
{
    private readonly IMongoCollection<RestaurantModel> _restaurantsCollection;

    public ReplaceService(
        ISetupService<RestaurantDataBaseSettings, RestaurantModel> setupService
    )
    {
        _restaurantsCollection = setupService.Setup();
    }
    public async Task<ReplaceOneResult> ReplaceOneAsync(Guid restaurantId, RestaurantModel restaurantModel)
    {
        var filter = Builders<RestaurantModel>
            .Filter
            .Eq(p => p.RestaurantId, restaurantId);

        var existing = await _restaurantsCollection
            .Find(filter)
            .FirstOrDefaultAsync();

        if(existing is null)
            throw new Exception("Not found restaurant!");

        return await _restaurantsCollection.ReplaceOneAsync(filter, restaurantModel);
    }
}