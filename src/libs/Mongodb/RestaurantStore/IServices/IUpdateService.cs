using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;

namespace Mongodb.RestaurantStore.IServices;

public interface IUpdateService
{
    Task<UpdateResult> UpdateOneAsync(Guid restaurantId, RestaurantModel restaurantModel);
    Task<UpdateResult> UpdatManyAsync(Guid restaurantId, RestaurantModel restaurantModel);

}