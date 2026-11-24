using lab14.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab14.ViewComponents
{
    public class TheLoaiViewComponent:ViewComponent
    {
        private QLNhaSachContext con;
        public TheLoaiViewComponent(QLNhaSachContext str)
        {
            con = str;
        }
        public IViewComponentResult Invoke()

        {
            var theLoai = con.TheLoais.ToList();
            return View("~/Views/Shared/NTML_Header.cshtml",theLoai);
        }
    }
    
}
