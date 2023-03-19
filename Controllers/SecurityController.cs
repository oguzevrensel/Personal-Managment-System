using PersonelMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVC.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        PersonelDBEntities db = new PersonelDBEntities();
        // GET: Security
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var model = db.Users.FirstOrDefault(a => a.UserName == userName && a.Password == password);
                if (model != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Department");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("login");
        }
    }
}