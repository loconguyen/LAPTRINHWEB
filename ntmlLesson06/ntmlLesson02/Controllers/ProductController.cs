using Microsoft.AspNetCore.Mvc;

namespace test3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult IndexProduct   ()
        {
            return View();
        }
    }
}
