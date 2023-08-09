using Mongodb.Commons.IServices;
using Mongodb.RestaurantStore.Datas;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;

namespace Mongodb.RestaurantStore.Services;

public class UpdateService : IUpdateService
{
    private readonly IMongoCollection<RestaurantModel> _restaurantsCollection;

    public UpdateService(
        ISetupService<RestaurantDataBaseSettings, RestaurantModel> setupService
    )
    {
        _restaurantsCollection = setupService.Setup();
    }
    public async Task<UpdateResult> UpdateOneAsync(Guid restaurantId, RestaurantModel restaurantModel)
    {
        var filter = Builders<RestaurantModel>
            .Filter
            .Eq(p => p.RestaurantId, restaurantId);

        var update = Builders<RestaurantModel>
            .Update
            .Set(p => p.Address.Building, restaurantModel.Address.Building);

        return await _restaurantsCollection.UpdateOneAsync(filter, update);
    }

    public async Task<UpdateResult> UpdatManyAsync(Guid restaurantId, RestaurantModel restaurantModel)
    {

        var filter = Builders<RestaurantModel>
            .Filter
            .Eq(p => p.RestaurantId, restaurantId);

        var update = Builders<RestaurantModel>
            .Update
            .Set(p => p.Address.Building, restaurantModel.Address.Building);

        return await _restaurantsCollection.UpdateManyAsync(filter, update);
    }
}