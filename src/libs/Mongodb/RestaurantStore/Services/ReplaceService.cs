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
    public Task ReplaceOneAsync(Guid restaurantId, RestaurantModel restaurantModel)
    {
        throw new NotImplementedException();
    }
}