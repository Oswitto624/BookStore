using BookStore.Domain.Entities.Base;

namespace BookStore.Domain.Entities;

public class Author : NamedEntity
{
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}
