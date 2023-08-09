using Mongodb.RestaurantStore.Models;

namespace Mongodb.RestaurantStore.IServices;

public interface IInsertServcie
{
    Task InsertOneAsync(RestaurantModel restaurantModel);
    Task InsertManyAsync(IEnumerable<RestaurantModel> restaurantModels);

}