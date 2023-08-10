using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;

namespace Mongodb.RestaurantStore.IServices;

public interface IReplaceService
{
    Task<ReplaceOneResult> ReplaceOneAsync(Guid restaurantId, RestaurantModel restaurantModel);
}