using DeThi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DeThi.Controllers
{
    public class HomeController : Controller
    {
        private QLHangHoa _context;
        public HomeController(QLHangHoa context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var hangHoa = _context.HangHoas.Where(sp => sp.Gia >= 100).ToList();
            return View(hangHoa);
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

        public IActionResult LocHangHoa(int maLoai)
        {
            var hangHoa = _context.HangHoas.AsQueryable();
            if (maLoai > 0)
            {
                hangHoa = hangHoa.Where(sp => sp.MaLoai == maLoai);
            }
            return PartialView("_DanhSachHangHoa", hangHoa.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoaiHang = new SelectList(_context.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            return View(new HangHoaViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HangHoaViewModel model)
        {
            if (!await _context.LoaiHangs.AnyAsync(loai => loai.MaLoai == model.MaLoai))
            {
                ModelState.AddModelError(nameof(model.MaLoai), "Vui lòng chọn loại hàng hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.LoaiHang = new SelectList(_context.LoaiHangs.ToList(), "MaLoai", "TenLoai", model.MaLoai);
                return View(model);
            }

            _context.HangHoas.Add(new HangHoa
            {
                MaLoai = model.MaLoai,
                TenHang = model.TenHang,
                Gia = model.Gia,
                Anh = model.Anh
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
