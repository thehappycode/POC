using Mongodb.RestaurantStore.Models;

namespace Mongodb.RestaurantStore.IServices;

public interface IFindService
{
    Task<RestaurantModel?> FindOneAsyncUsingBuilders(Guid restaurantId);
    Task<RestaurantModel?> FindOneAsyncUsingLinq(Guid restaurantId);
    Task<IEnumerable<RestaurantModel>> FindManyAsyncUsingBuilders(IEnumerable<Guid>restaurantIds);
    Task<IEnumerable<RestaurantModel>> FindManyAsyncUsingLinq(IEnumerable<Guid>restaurantIds);
}