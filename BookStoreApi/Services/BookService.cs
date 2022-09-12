using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;
public class BookService
{
    private readonly IMongoCollection<Book> books;

    public BookService(IOptions<BookStoreDatabaseSettings> settings)
    {
        MongoClient client = new(settings.Value.ConnectionString);
        IMongoDatabase db = client.GetDatabase(settings.Value.DatabaseName);
        books = db.GetCollection<Book>(settings.Value.BooksCollectionName);
    }

    public async Task<List<Book>> GetAsync() =>
        await books
            .Find(_ => true)
            .ToListAsync();

    public async Task<Book?> GetAsync(string id) =>
        await books
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();

    public async Task CreateAsync(Book book) =>
        await books
            .InsertOneAsync(book);

    public async Task UpdateAsync(string id, Book book) =>
        await books
            .ReplaceOneAsync(x => x.Id == id, book);

    public async Task RemoveAsync(string id) =>
        await books
            .DeleteOneAsync(x => x.Id == id);
}