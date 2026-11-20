using DeThi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeThi.ViewComponents
{
    public class LoaiHangViewComponent : ViewComponent
    {
        private QLHangHoa _context;
        public LoaiHangViewComponent(QLHangHoa context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var loaiHang = _context.LoaiHangs.ToList();
            return View("~/Views/Shared/_Header.cshtml", loaiHang);
        }
    }
}
