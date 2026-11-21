using Microsoft.AspNetCore.Mvc;
using NguyenThiMinhLocDe2.Models;

namespace NguyenThiMinhLocDe2.ViewComponents
{
    public class LoaiTaiSanViewComponent:ViewComponent
    {
        private QLTaiSanContext _context;
        public LoaiTaiSanViewComponent(QLTaiSanContext c)
        {
            _context = c;
        }
        public IViewComponentResult Invoke()
        {
            var loai = _context.LoaiTaiSans.ToList();
            return View("~/Views/Shared/NTML_Header.cshtml", loai);
        }
    }
}
