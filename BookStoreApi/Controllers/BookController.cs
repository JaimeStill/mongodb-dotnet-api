using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    readonly BookService bookSvc;

    public BookController(BookService svc) =>
        bookSvc = svc;

    [HttpGet]
    public async Task<List<Book>> Get() =>
        await bookSvc.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await bookSvc.GetAsync(id);

        if (book is null)
            return NotFound();

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Book book)
    {
        await bookSvc.CreateAsync(book);
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book book)
    {
        var record = await bookSvc.GetAsync(id);

        if (record is null)
            return NotFound();

        book.Id = record.Id;

        await bookSvc.UpdateAsync(id, book);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await bookSvc.GetAsync(id);

        if (book is null)
            return NotFound();

        await bookSvc.RemoveAsync(id);

        return NoContent();
    }
}