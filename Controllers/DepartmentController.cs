﻿using PersonelMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{

    
    public class DepartmentController : Controller
    {
        PersonelDBEntities db = new PersonelDBEntities();

        
        
        public ActionResult Index()
        {
            IEnumerable<Department> departments = db.Departments.ToList();
            return View(departments);
        }

        [HttpGet]        
        public ActionResult Save()
        {
            Department model = new Department();
            return View("manager",model);
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {

            if (department != null && ModelState.IsValid)
            {
                if (department.Id > 0)
                {
                    db.Entry(department).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.Departments.Add(department);
                }

                db.SaveChanges();
            }
            else
            {
                return View("manager", department);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public ActionResult Update(int id)
        {
            Department model = db.Departments.Find(id);
            if(model == null) return HttpNotFound();

            return View("manager",model);
        }

        
        public JsonResult Delete(int id)
        {
            Department department = db.Departments.Find(id);
            

            db.Departments.Remove(department);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
            
        }

    }


}