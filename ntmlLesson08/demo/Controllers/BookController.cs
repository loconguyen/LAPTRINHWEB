using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ntmlLesson08.Models;


namespace ntmlLesson08.Controllers
{
    public class BookController : Controller
    {
        // khai bao 1 truong de controller lam vc voi csdl
        private readonly BookManagementContext _context;
        // constructor
        public BookController(BookManagementContext context)
        {
            _context = context;
        }
        //_context.Books-> return : DbSet<Book>
        //_context.Books.Tolist() -> return : list<Book>

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(b=> b.Category)
                .Include(b => b.Publisher)
                .AsNoTracking()// ko yeu cau EF core theo doi thay doi cua cac entity dc truy van
                .ToListAsync();// task<list<book>> -> list<book>
            return View(books);
        }
        [HttpGet]

        public  IActionResult Details(string id)
        {
            var books = _context.Books.ToList();
            var book = books.FirstOrDefault(b => b.BookId == id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);

        }
    }
}
