using MongoDB.Driver;

namespace Mongodb.RestaurantStore.IServices;

public interface IDeleteService
{
    Task<DeleteResult> DeleteOneAsync(Guid id);
    Task<DeleteResult> DeleteManyAsync(Guid id);
}