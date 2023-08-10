using Microsoft.Extensions.Options;
using Mongodb.BookStore.Datas;
using Mongodb.BookStore.Models;
using Mongodb.Commons.IServices;
using Mongodb.IServices;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Mongodb.Service;

public class BooksService : IBooksService
{
    private readonly IMongoCollection<BookModel> _booksCollection;

    public BooksService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings
    )
    {
        _booksCollection = bookStoreDatabaseSettings.Value.Setup();
    }

    public async Task<BookModel?> GetAsync(Guid id) =>
        await _booksCollection.Find(p => p.Id == id)
            .FirstOrDefaultAsync();

    public async Task<List<BookModel>> GetListAsync() =>
        await _booksCollection.Find(_ => true)
            .ToListAsync();

    public async Task<List<BookModel>> SearchAsync(SearchModel search)
    {
        // Fileter
        IMongoQueryable<BookModel> queryable = _booksCollection.AsQueryable();

        if (search.TextSearch is not null)
        {

            queryable = queryable.Where(p => p.BookName == search.TextSearch
                || p.Author == search.TextSearch
            );

            decimal? price = null;
            if (Decimal.TryParse(search.TextSearch, out decimal p))
                price = p;

            if (price is not null)
                queryable = queryable.Where(p => p.Price == price);
        }

        // Sort Order
        switch ((int)search.SearchSortOrder)
        {
            case (int)SearchSortOrderConstant.BookName:
                queryable = queryable.OrderBy(p => p.BookName);
                break;

            case (int)SearchSortOrderConstant.BookNameDesc:
                queryable = queryable.OrderByDescending(p => p.BookName);
                break;

            case (int)SearchSortOrderConstant.Price:
                queryable = queryable.OrderBy(p => p.Price);
                break;

            case (int)SearchSortOrderConstant.PriceDesc:
                queryable = queryable.OrderByDescending(p => p.Price);
                break;

            case (int)SearchSortOrderConstant.Category:
                queryable = queryable.OrderBy(p => p.Category);
                break;

            case (int)SearchSortOrderConstant.CategoryDesc:
                queryable = queryable.OrderByDescending(p => p.Category);
                break;

            case (int)SearchSortOrderConstant.Author:
                queryable = queryable.OrderBy(p => p.Author);
                break;

            case (int)SearchSortOrderConstant.AuthorDesc:
                queryable = queryable.OrderByDescending(p => p.Author);
                break;

            default:
                break;
        }

        // Pagination
        return await queryable.Skip(search.Skip).Take(search.Take)
            .ToListAsync();
    }

    public async Task CreateAsync(BookModel book) =>
        await _booksCollection.InsertOneAsync(book);

    public async Task UpdateAsync(Guid id, BookModel book) =>
        await _booksCollection.ReplaceOneAsync(p => p.Id == id, book);

    public async Task RemoveAsync(Guid id) =>
        await _booksCollection.FindOneAndDeleteAsync(p => p.Id == id);

}