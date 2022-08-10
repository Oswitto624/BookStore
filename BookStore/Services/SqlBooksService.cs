using BookStore.DAL.Context;
using BookStore.Domain.Entities;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

public class SqlBooksService : IBooksService
{
    private readonly BookStoreDB _db;
    private readonly ILogger<SqlBooksService> _Logger;

    public SqlBooksService(BookStoreDB db, ILogger<SqlBooksService> logger)
    {
        _db = db;
        _Logger = logger;
    }

    public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken Cancel = default)
    {
        var books = await _db.Books.Include(c => c.Author).ToArrayAsync(Cancel).ConfigureAwait(false);
        return books;
    }

    public async Task<Book?> GetByIdAsync(int id, CancellationToken Cancel = default)
    {
        var book = await _db.Books
            .Include(c => c.Author)
            .FirstOrDefaultAsync(c => c.Id == id, Cancel)
            .ConfigureAwait(false);
        return book;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken Cancel = default)
    {
        var db_book = await GetByIdAsync(id, Cancel);

        if (db_book is null)
        {
            _Logger.LogWarning("Попытка удаления несуществующей книги с id:{0}", id);
            return false;
        }

        _db.Remove(db_book);
        await _db.SaveChangesAsync(Cancel);

        _Logger.LogInformation("Книга c id:{0} удалена.", id);

        return true;
    }

}
