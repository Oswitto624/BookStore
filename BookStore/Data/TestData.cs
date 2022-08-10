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
                Name = "Последнее желание",
                Author = authors[0],
                PublicationDate = 1990,
            },
            new() {
                Name = "Башня Ласточки",
                Author = authors[0],
                PublicationDate = 1997,
            },
            new() {
                Name = "Краткая история времени",
                Author = authors[1],
                PublicationDate = 2001,
            },
            new() {
                Name = "Теория всего",
                Author = authors[1],
                PublicationDate = 2009,
            },
            new() {
                Name = "Язык программирования C#9 и платформа .NET 5",
                Author = authors[2],
                PublicationDate = 2022,
            },
            new() {
                Name = "C# и платформа .NET 3.0",
                Author = authors[2],
                PublicationDate = 2008,
            },
            new() {
                Name = "Симулякры и симуляция",
                Author = authors[3],
                PublicationDate = 1981,
            },
            new() {
                Name = "Прозрачность зла",
                Author = authors[3],
                PublicationDate = 1990,
            },
            new() {
                Name = "Хоббит, или Туда и обратно",
                Author = authors[4],
                PublicationDate = 1937,
            },
            new() {
                Name = "Две крепости",
                Author = authors[4],
                PublicationDate = 1954,
            },
            new() {
                Name = "Марсианские хроники",
                Author = authors[5],
                PublicationDate = 1950,
            },
            new() {
                Name = "451 градус по Фаренгейту",
                Author = authors[5],
                PublicationDate = 1953,
            },
            new() {
                Name = "Двухсотлетний человек",
                Author = authors[6],
                PublicationDate = 1954,
            },
            new() { 
                Name = "Основание",
                Author = authors[6],
                PublicationDate = 1992,
            },
            new() {
                Name = "1984",
                Author = authors[7],
                PublicationDate = 1949,
            },
            new() {
                Name = "Скотный двор",
                Author = authors[7],
                PublicationDate = 1945,
            },
        };

        Authors = authors;
        Books = books;
    }

    public static ICollection<Author> Authors { get; }
    public static ICollection<Book> Books { get; }
}
