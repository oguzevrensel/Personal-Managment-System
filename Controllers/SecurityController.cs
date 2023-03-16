using PersonelMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    public class SecurityController : Controller
    {
        PersonelDBEntities db = new PersonelDBEntities();
        // GET: Security
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("Login"), HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var model = db.Users.FirstOrDefault(a => a.UserName == userName && a.Password == password);
                    if(model!= null)
                    {
                        return RedirectToAction("homepage","department");
                    }
            }
            return View();
        }
    }
}