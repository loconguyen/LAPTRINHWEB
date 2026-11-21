using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenThiMinhLocDe1.Models;
using System.Diagnostics;

namespace NguyenThiMinhLocDe1.Controllers
{
    public class HomeController : Controller
    {
        private QLTaiSanContext _context;
        public HomeController(QLTaiSanContext context)
        {
            _context = context;
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

        public IActionResult Index()
        {
            var taisan = _context.TaiSans.Where(a => a.NguyenGia >= 20).ToList();
            return View(taisan);
        }
        public IActionResult LocTaiSan(int maLoai)
        {
            var ds = _context.TaiSans.AsQueryable();
            if(maLoai > 0)
            {
                ds = ds.Where(a => a.MaLoai == maLoai);
            }
            return PartialView("_DanhSachTaiSan", ds.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans.ToList(),"MaLoai","TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaiSan ts)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                _context.TaiSans.Add(ts);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans.ToList(), "MaLoai", "TenLoai",ts.MaLoai);
            return View(ts);
        }

    }
}
