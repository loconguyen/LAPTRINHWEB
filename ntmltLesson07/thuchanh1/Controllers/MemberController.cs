using Microsoft.AspNetCore.Mvc;
using ntmltLesson07.Models.DataModels;
using ntmltLesson07.Models.ViewModels;
using System.Text.RegularExpressions;
namespace ntmltLesson07.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> members = new List<Member>();
        [HttpGet]
        public IActionResult Index()
        {
            return View(members);
        }
        [HttpPost]
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    Username = register.UserName,
                    Fullname = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.Birthday,
                };
                members.Add(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View(register);

            }
           
        }
        //[HttpPost]
        //public IActionResult Create(Member member)
        //{
        //    string msg = null;
        //    bool validate = true;
        //    if(member.Username.Length < 3 || member.Username.Length > 20)
        //    {
        //        msg = "<li> ten dang nhap phai co do dai tu 3-20 ki tu </li>";
        //        validate = false;
        //    }
        //    string patteremail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2, 4}$";
        //    if(!Regex.IsMatch(member.Email, patteremail))
        //    {
        //        msg += "<li>Email không đúng định dạng</li>";
        //        validate = false;
        //    }
        //    if (member.Birthday.AddYears(18) > DateTime.Now)
        //    {
        //        msg += "<li>Bạn chưa đủ 18 tuổi</li>";
        //        validate = false;
        //    }
        //    string patternphone = @"^0\d{9,12}$";
        //    if (!Regex.IsMatch(member.Phone, patternphone))
        //    {
        //        msg += "<li>Số điện thoại không hợp lệ</li>";
        //        validate = false;
        //    }
        //    if (validate)
        //    {
        //        member.MemberId = Guid.NewGuid().ToString();
        //        members.Add(member);
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        ViewBag.msg = "<div class='alert alert-danger'>" + msg + "</div>";
        //            return View(member);
        //    }
            
            
        //}
    }
}
