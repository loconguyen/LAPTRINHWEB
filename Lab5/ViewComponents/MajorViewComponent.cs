using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
namespace Lab5.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly SchoolContext db;
        public MajorViewComponent(SchoolContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var majors = await db.Majors.ToArrayAsync();
            return View("RenderMajor", majors);
        }
    }
}
