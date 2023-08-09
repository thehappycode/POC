using Mongodb.RestaurantStore.Models;

namespace Mongodb.RestaurantStore.IServices;

public interface IReplaceService
{
    Task ReplaceOneAsync(Guid restaurantId, RestaurantModel restaurantModel);
}