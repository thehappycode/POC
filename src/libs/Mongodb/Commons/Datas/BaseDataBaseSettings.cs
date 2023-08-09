namespace Mongodb.Commons.Datas;

public class BaseDataBaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string BooksCollectionName { get; set; } = null!;
}