using Microsoft.AspNetCore.Mvc;

namespace ntmlLesson09.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
