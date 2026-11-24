using lab14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace lab14.Controllers
{
    public class HomeController : Controller
    {
        private QLNhaSachContext con;
        public HomeController(QLNhaSachContext str)
        {
            con = str;
        }
        public IActionResult Index()
        {
            var ds = con.Saches.Where(s => s.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]

        public IActionResult LocSach(int maTl)
        {
            var ds = con.Saches.AsQueryable();
            if (maTl > 0)
            {
                ds = ds.Where(s => s.MaTl == maTl);
            }
            return PartialView("~/Views/Home/_DanhSach.cshtml", ds.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TheLoai = new SelectList(con.TheLoais.ToList(), "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sach s)
        {
            ModelState.Remove("MaTlNavigation");
            if (ModelState.IsValid)
            {
                con.Saches.Add(s);
                con.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TheLoai = new SelectList(con.TheLoais.ToList(),"MaTl","TenTl",s.MaTl);
            return View();
        }
    }
    
}
