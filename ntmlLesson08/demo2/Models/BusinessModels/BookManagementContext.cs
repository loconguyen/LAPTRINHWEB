using Microsoft.EntityFrameworkCore;
namespace demo2.Models.BusinessModels
{
    // dbcontext : 
    public class BookManagementContext:DbContext
    {
        public BookManagementContext(DbContextOptions<BookManagementContext> options):base(options)
        {

        }
        public DbSet<Book> Books
    }
}
