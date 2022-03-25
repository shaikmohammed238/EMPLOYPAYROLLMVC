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
        private readonly IemployeeBL  iemployeeBL;

        public EmployeeController(IemployeeBL iemployeeBL)
        {
            this.iemployeeBL = iemployeeBL;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
