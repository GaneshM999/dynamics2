using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dynamics2.AppDbContext;
using dynamics2.Models;

namespace dynamics2.Controllers
{
    public class EmployeeController : Controller
    {
        public MyAppDbContext context = new MyAppDbContext();
        public ActionResult Index()
        {
            var employees = context.Employees.Include("Department").ToList();
            return View(employees);
        }
        public ActionResult Create() 
        {
            ViewModel vm = new ViewModel
            {
                Department = GetDepartments()

            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(ViewModel vm)
        {
            if(ModelState.IsValid)
            {
                context.Employees.Add(vm.Employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public ActionResult Edit(int id) 
        {
            var employee = context.Employees.Find(id);
            ViewModel vm = new ViewModel
            {
                Employee=employee,
                Department = GetDepartments()

            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(ViewModel vm)
        {
            if(ModelState.IsValid)
            {
                context.Entry(vm.Employee).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(vm);
        }
        public ActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            ViewModel vm = new ViewModel
            {
                Employee = employee,
                Department = GetDepartments()

            };
            return View(vm);
        }
        public ActionResult Delete(int? id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        private IEnumerable<SelectListItem> GetDepartments()
        {
            return context.Departments.Select(d => new SelectListItem
            {
                Value = d.DId.ToString(),
                Text = d.DName

            }).ToList();
        }
    }
}