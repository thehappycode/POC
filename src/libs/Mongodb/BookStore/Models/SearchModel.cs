namespace Mongodb.BookStore.Models;

public class SearchModel
{
    public string? TextSearch { get; set; } = null!;
    public int Skip { get; set; }
    public int Take { get; set; }
    public SearchSortOrderConstant SearchSortOrder { get; set; } = 0;
}