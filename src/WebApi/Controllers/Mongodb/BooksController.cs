using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mongodb.BookStore.Models;
using Mongodb.IServices;

namespace WebApi.Controllers.Mongodb;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(
        IBooksService booksService
    )
    {
        _booksService = booksService;
    }

    [HttpGet("GetListAsync")]
    public async Task<IActionResult> GetListAsync() =>
        Ok(await _booksService.GetListAsync());

    [ActionName(nameof(GetAsync))]
    [HttpGet("GetAsync/{id}")]
    public async Task<IActionResult> GetAsync([FromQuery] Guid id)
    {
        var book = await _booksService.GetAsync(id);
        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost("SearchAsync")]
    public async Task<IActionResult> SearchAsync([FromBody] SearchModel search) =>
        Ok(await _booksService.SearchAsync(search));

    [HttpPost("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] BookModel book)
    {
        await _booksService.CreateAsync(book);
        var actionName = nameof(GetAsync);
        var routeValues = new { id = book.Id };
        return CreatedAtAction(actionName, routeValues, book);
    }

    [HttpPut("UpdateAsync/{id}")]
    public async Task<IActionResult> UpdateAsync([FromQuery] Guid id, [FromBody] BookModel book)
    {
        var existingBook = await _booksService.GetAsync(id);
        if (existingBook is null)
            return NotFound();

        book.Id = existingBook.Id;
        await _booksService.UpdateAsync(id, book);

        return CreatedAtAction(nameof(GetAsync), new { id = id }, book);
    }

    [HttpDelete("RemoveAsync/{id}")]
    public async Task<IActionResult> RemoveAsync([FromQuery] Guid id)
    {
        var existingBook = await _booksService.GetAsync(id);
        if (existingBook is null)
            return NotFound();

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}