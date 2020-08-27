using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers 
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            //return Json(new {id = 1, name33 = "Tochi" }); ;
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) {
                Employee newEmployee = _employeeRepository.Add(employee);
                //return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }

        public ViewResult StrongType()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.pageTitle = "Using C# Strongly Typed View";
            return View(model);
        }

        //[Route("Home/Details/{id}")]
        public ViewResult Details(int Id, string name)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(Id),
                PageTitle = "Using C# View Data"
            };
            return View(homeDetailsViewModel);
        }
            
         
        public ViewResult Details22()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.pageTitle = "Using C# View Bag";
            ViewBag.employeeData = model;
            return View();
        }
    }
}
