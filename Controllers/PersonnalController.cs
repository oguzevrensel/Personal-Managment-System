using PersonelMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVC.ViewModels;

namespace PersonelMVC.Controllers
{
    
    public class PersonnalController : Controller
    {
        PersonelDBEntities db = new PersonelDBEntities();
        // GET: Personnal
        
        public ActionResult Index()
        {
            IEnumerable<Personnal> personnals = db.Personnals.Include(x => x.Department).ToList();
            return View(personnals);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Save()
        {
            PersonalManagerVM model = new PersonalManagerVM()
            {
                Departments = db.Departments.ToList(),
                Personnal = new Personnal()
            };
            return View("Manager",model); 
        }

        [HttpPost]
        
        public ActionResult Save(Personnal personnal)
        {
            if(personnal != null && ModelState.IsValid)
            {
                if (personnal.Id > 0)
                {
                    db.Entry(personnal).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.Personnals.Add(personnal);
                }

                db.SaveChanges();
            }
            else
            {
                return View("manager", personnal);
            }
       
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            PersonalManagerVM model = new PersonalManagerVM()
            {
                Departments = db.Departments.ToList(),
                Personnal = db.Personnals.Find(id)
            };

            if (model == null) return HttpNotFound();

            return View("manager",model);
        }

            
        public ActionResult Delete(int id)
        {
            Personnal personnal = db.Personnals.Find(id);
            if (personnal == null) return HttpNotFound();

            db.Personnals.Remove(personnal);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

    }


}