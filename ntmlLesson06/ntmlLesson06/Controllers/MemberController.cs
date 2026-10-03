using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ntmlLesson06.Models.DataModel;

namespace ntmlLesson06.Controllers
{
    public class MemberController : Controller
    {
        //mock data: du lieu gia dinh de testing
        private static readonly List<Member> _ntmlMembers = new List<Member>
        {
            new Member
                {
                    ntmlMemberId = Guid.NewGuid().ToString(),
                    Username = "nguyen thi minh loc",
                    Password = "123",
                    Email = "nguyena@gmail.com",
                    Fullname = "Nguyễn Thị Minh Lộc"
                },
                new Member
                {
                    ntmlMemberId = Guid.NewGuid().ToString(),
                    Username = "tranb",
                    Password = "123",
                    Email = "tranb@gmail.com",
                    Fullname = "Trần Thị B"
                },
                new Member
                {
                    ntmlMemberId = Guid.NewGuid().ToString(),
                    Username = "lethanhc",
                    Password = "123",
                    Email = "lethanhc@gmail.com",
                    Fullname = "Lê Thành C"
                }
        };




        // GET: MemeberController
        public ActionResult Index()
        {

            return View(_ntmlMembers);
        }

        // GET: MemeberController/Details/5
        public ActionResult Details()
        {
            var ntmlMember = new Member()
            {
                ntmlMemberId = Guid.NewGuid().ToString(),
                Username = "Nguyễn Thị Minh Lộc",
                Password = "123",
                Fullname="NGUYEN THI MINH LOC",
                Email = "shengloc12@gmail.com"

            };

            return View(ntmlMember);
        }

        // GET: MemeberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemeberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemeberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemeberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemeberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemeberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
