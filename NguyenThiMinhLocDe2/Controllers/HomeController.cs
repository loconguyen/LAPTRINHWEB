using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenThiMinhLocDe2.Models;
using System.Diagnostics;

namespace NguyenThiMinhLocDe2.Controllers
{
    public class HomeController : Controller
    {
        private QLTaiSanContext _context;
        public HomeController(QLTaiSanContext c)
        {
            _context = c;
        }
        public IActionResult Index()
        {
            var ds = _context.TaiSans.Where(a => a.NguyenGia >= 20).ToList();
            return PartialView(ds);
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
        public IActionResult Sua(int id)
        {
            var ts = _context.TaiSans.Find(id);
            if(ts == null)
            {
                return NotFound();
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }
        [HttpPost]
        public IActionResult Sua(TaiSan t)
        {
            var ts = _context.TaiSans.Find(t.MaTs);
            if(ts == null)
            {
                return NotFound();
            }
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                ts.MaLoai = t.MaLoai;
                ts.TenTs = t.TenTs;
                ts.NguyenGia = t.NguyenGia;
                ts.Anh = t.Anh;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai= new SelectList(_context.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", t.MaLoai);
            return View(t);
        }
    }
}
