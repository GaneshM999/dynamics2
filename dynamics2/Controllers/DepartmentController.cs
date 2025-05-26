using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dynamics2.AppDbContext;
using dynamics2.Models;

namespace dynamics2.Controllers
{
    public class DepartmentController : Controller
    {
        private MyAppDbContext context = new MyAppDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            var departments = context.Departments.ToList();
            return View(departments);
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}