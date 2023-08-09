using Mongodb.Commons.Datas;
using MongoDB.Driver;

namespace Mongodb.Commons.IServices;

public interface ISetupService <O, T> 
     where O : BaseDataBaseSettings
     where T : class
{
     IMongoCollection<T> Setup();
}