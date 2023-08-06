namespace Mongodb.BookStore.Datas;

public class BookStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string BooksCollectionName { get; set; } = null!;
}