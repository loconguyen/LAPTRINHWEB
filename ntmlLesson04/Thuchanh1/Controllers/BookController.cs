using Microsoft.AspNetCore.Mvc;
using Thuchanh1.Models;
namespace Thuchanh1.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        public IActionResult BookIndex()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            var books = book.GetBookList();

            return View(books);
        }
        public IActionResult CreateIndex()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);

        }
    }
}
