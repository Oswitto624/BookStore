using BookStore.Domain;
using BookStore.Models;
using BookStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksService _BooksData;
        private readonly ILogger<HomeController> _Logger;

        public HomeController(IBooksService BooksData, ILogger<HomeController> Logger)
        {
            _BooksData = BooksData;
            _Logger = Logger;
        }
        
        public async Task<IActionResult> Index(SortState sortOrder = SortState.IdAsc)
        {
            var books = await _BooksData.GetAllAsync();

            #region Sort

            ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            ViewData["BookNameSort"] = sortOrder == SortState.BookNameAsc ? SortState.BookNameDesc : SortState.BookNameAsc;
            ViewData["AutorSort"] = sortOrder == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            ViewData["PublicationDateSort"] = sortOrder == SortState.PublicationDateAsc ? SortState.PublicationDateDesc : SortState.PublicationDateAsc;

            books = sortOrder switch
            {
                SortState.IdAsc => books.OrderBy(s => s.Id),
                SortState.BookNameAsc => books.OrderBy(s => s.Name),
                SortState.AuthorAsc => books.OrderBy(s => s.Author.Name),
                SortState.PublicationDateAsc => books.OrderBy(s => s.PublicationDate),
                SortState.IdDesc => books.OrderByDescending(s => s.Id),
                SortState.BookNameDesc => books.OrderByDescending(s => s.Name),
                SortState.AuthorDesc => books.OrderByDescending(s => s.Author.Name),
                SortState.PublicationDateDesc => books.OrderByDescending(s => s.PublicationDate),
                _ => books.OrderBy(s => s.Id),
            };

            #endregion

            return View(books);
        }
    }
}