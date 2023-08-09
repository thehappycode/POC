using Mongodb.Commons.IServices;
using Mongodb.RestaurantStore.Datas;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Mongodb.RestaurantStore.Services;

public class FindService : IFindService
{
    private readonly IMongoCollection<RestaurantModel> _restaurantsCollection;

    public FindService(
        ISetupService<RestaurantDataBaseSettings, RestaurantModel> setupService
    )
    {
        _restaurantsCollection = setupService.Setup();
    }

    public async Task<RestaurantModel?> FindOneAsyncUsingBuilders(Guid restaurantId)
    {
        var filter = Builders<RestaurantModel>
            .Filter.Eq(p => p.RestaurantId, restaurantId);

        return await _restaurantsCollection
            .Find(filter)
            .FirstOrDefaultAsync();
    }

    public async Task<RestaurantModel?> FindOneAsyncUsingLinq(Guid restaurantId)
    {
        var queryable = _restaurantsCollection.AsQueryable();
        return await queryable.FirstOrDefaultAsync(p => p.RestaurantId == restaurantId);
    }

    public async Task<IEnumerable<RestaurantModel>> FindManyAsyncUsingBuilders(IEnumerable<Guid> restaurantIds)
    {
        var filter = Builders<RestaurantModel>
            .Filter.In(p => p.RestaurantId, restaurantIds);

        return await _restaurantsCollection
            .Find(filter)
            .ToListAsync();
    }

    public async Task<IEnumerable<RestaurantModel>> FindManyAsyncUsingLinq(IEnumerable<Guid> restaurantIds)
    {
        var queryable = _restaurantsCollection.AsQueryable();
        return await queryable.Where(p => restaurantIds.Contains(p.RestaurantId))
            .ToListAsync();
    }
}