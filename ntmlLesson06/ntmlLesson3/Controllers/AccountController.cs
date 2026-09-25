using System.Security.Cryptography.X509Certificates;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using ntmlLesson3.Models;
namespace ntmlLesson3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccountIndex()
        {
            List<Account> accounts = new List<Account>
            {
                new Account(){ Id=1,Name="hoang anh", Email="anh@gmail.com",  Phone="09876433",Address="ha noi",Avatar=Url.Content("/images/Avatar/1.png"),Gender=1,Bio="my name is saml",Birthday=new DateTime(1988,7,3)},
                new Account(){ Id=1,Name="le viet", Email="anh@gmail.com",  Phone="09876433",Address="ha noi",Avatar=Url.Content("/images/Avatar/1.png"),Gender=1,Bio="my name is saml",Birthday=new DateTime(1988,7,3)},
                new Account(){ Id=1,Name="minh loc", Email="anh@gmail.com",  Phone="09876433",Address="ha noi",Avatar=Url.Content("/images/Avatar/1.png"),Gender=1,Bio="my name is saml",Birthday=new DateTime(1988,7,3)},
            };

            ViewBag.accounts = accounts;
            return View();
        }
    }
}
