using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IemployeeBL iemployeeBL;

        public EmployeeController(IemployeeBL iemployeeBL)
        {
            this.iemployeeBL = iemployeeBL;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = iemployeeBL.GetAllEmployee().ToList();

            return View(lstEmployee);
        }
        /// <summary>
        /// API FOR INSERT
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                iemployeeBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //EDIT
        [HttpGet]
        public IActionResult Edit(int? EmpId)
        {
            if (EmpId == null)
            {
                return NotFound();
            }
            Employee employee = iemployeeBL.GetEmployeeData(EmpId);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int EmpId, [Bind] Employee employee)
        {
            if (EmpId != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iemployeeBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //deelte
        [HttpGet]
        public IActionResult Delete(int? EmpId)
        {
            if (EmpId == null)
            {
                return NotFound();
            }
            Employee employee = iemployeeBL.GetEmployeeData(EmpId);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? EmpId)
        {
            iemployeeBL.DeleteEmployee(EmpId);
            return RedirectToAction("Index");
        }
        //DETAILS
        [HttpGet]
        public IActionResult Details(int? EmpId)
        {
            if (EmpId == null)
            {
                return NotFound();
            }
            Employee employee = iemployeeBL.GetEmployeeData(EmpId);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

    }
}
