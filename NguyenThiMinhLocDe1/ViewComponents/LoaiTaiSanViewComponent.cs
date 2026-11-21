using Microsoft.AspNetCore.Mvc;
using NguyenThiMinhLocDe1.Models;
namespace NguyenThiMinhLocDe1.ViewComponents
{
    public class LoaiTaiSanViewComponent : ViewComponent
    {
        private QLTaiSanContext _context;
        public LoaiTaiSanViewComponent(QLTaiSanContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var loai = _context.LoaiTaiSans.ToList();
            return View("~/Views/Shared/NTML_Header.cshtml", loai);
        }
    }
}
