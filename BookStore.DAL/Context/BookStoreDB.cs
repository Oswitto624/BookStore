using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Context;

public class BookStoreDB : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Author { get; set; }

    public BookStoreDB(DbContextOptions<BookStoreDB> options) : base(options) { }
}
