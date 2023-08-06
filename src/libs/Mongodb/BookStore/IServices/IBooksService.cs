using Mongodb.BookStore.Models;

namespace Mongodb.IServices;

public interface IBooksService
{
    Task<BookModel?> GetAsync(Guid id);
    Task<List<BookModel>> GetListAsync();
    Task<List<BookModel>> SearchAsync(SearchModel search);
    Task CreateAsync(BookModel book);
    Task UpdateAsync(Guid id, BookModel book);
    Task RemoveAsync(Guid id);
}