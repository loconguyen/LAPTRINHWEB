using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.ViewComponent
{
    public class RenderViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();
        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Branches", Link = "/Branches/List" },
                new MenuItem { Id = 2, Name = "Students", Link = "/Admin/Student/List" },
                new MenuItem { Id = 3, Name = "Subjects", Link = "/Subjects/List" },
                new MenuItem { Id = 4, Name = "Courses", Link = "/Courses/List" }
            };

        }
        public IViewComponentResult Invoke()
        {
            return View("RenderLeftMenu", MenuItems);
        }
    }
}
