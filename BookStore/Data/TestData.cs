using BookStore.Domain.Entities;

namespace BookStore.Data;

public class TestData
{
    static TestData()
    {
        var authors = new Author[]
        {
            new() { Name = "Сапковский А."},
            new() { Name = "Хокинг С."},
            new() { Name = "Троелсен Э."},
            new() { Name = "Бодрийяр Ж."},
            new() { Name = "Толкин Дж. Р. Р."},
            new() { Name = "Брэдбери Р."},
            new() { Name = "Азимов А."},
            new() { Name = "Оруэлл Дж."},
        };

        var books = new Book[]
        {
            new() { 
                Name = "",
                Author = authors[0],
                PublicationDate = 1984,
            },

        };
    }
}
