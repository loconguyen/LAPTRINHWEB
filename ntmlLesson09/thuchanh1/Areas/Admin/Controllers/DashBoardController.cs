using Microsoft.AspNetCore.Mvc;

namespace thuchanh1.Areas.Admin.Controllers
{
    [Area("Admin")]// neu thieu thuoc tinh nay MVC ko nhan dien Controller la thanh vien cua admin
    public class DashBoardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
