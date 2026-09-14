using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Thuchanh1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        // danh sach cac cuon sach
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
            new Book()
            {
                Id = 1,
                Title = "Chi pheo",
                AuthorId = 1,
                GenreId = 1,
                Image = "/images/products/chipheo.jpg",
                Price = 5000,
                TotalPage = 250,
                Summary = ""
            },
            new Book()
            {
                Id = 2,
                Title = "Tat den",
                AuthorId = 2,
                GenreId = 2,
                Image = "",
                Price = 10000,
                TotalPage = 300,
                Summary = ""
            },
            new Book()
            {
                Id = 3,
                Title = "Lao hac",
                AuthorId = 3,
                GenreId = 3,
                Image = "",
                Price = 10000,
                TotalPage = 300,
                Summary = ""
            },
            new Book()
            {
                Id = 4,
                Title = "Conan phieu luu ki",
                AuthorId = 4,
                GenreId = 4,
                Image = "",
                Price = 10000,
                TotalPage = 300,
                Summary = ""
            },

            };
            return books;
        }
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Nguyen Huy Thiep" },
            new SelectListItem { Value = "3", Text = "Lao Hac" },
            new SelectListItem { Value = "4", Text = "Aoyama Gosho" },
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyen ngan" },
            new SelectListItem { Value = "2", Text = "Truyen dai" },
            new SelectListItem { Value = "3", Text = "Truyen co tich" },
            new SelectListItem { Value = "4", Text = "Truyen trinh tham" },
        };

    }
}
