using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;


namespace DotnetMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<EmployeeViewModel> _employeeViewModel = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel(
                    1,
                    "Apud",
                    "apud@rapidtech.sample",
                    "Man",
                    "Backend Dev",
                    "Active"
                ),
                new EmployeeViewModel(
                    2,
                    "Saefudin",
                    "saefudin@rapidtech.sample",
                    "Man",
                    "IT Consultant",
                    "Active"
                ),
                new EmployeeViewModel(
                    3,
                    "Fitri",
                    "fitri@rapidtech.sample",
                    "Woman",
                    "System Analyst",
                    "Active"
                ),
            };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult List()
        {

            return View(_employeeViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, Name, Email, Gender, JobPosition, Status")] EmployeeViewModel employee)
        {
            _employeeViewModel.Add(employee);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            EmployeeViewModel employee = _employeeViewModel.Find(x => x.Id.Equals(id));
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, Name, Email, Gender, JobPosition, Status")] EmployeeViewModel employee)
        {
            EmployeeViewModel employeeOld = _employeeViewModel.Find(x => x.Id.Equals(id));
            _employeeViewModel.Remove(employeeOld);

            _employeeViewModel.Add(employee);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            EmployeeViewModel employee = (
                from p in _employeeViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new EmployeeViewModel());
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            EmployeeViewModel employee = _employeeViewModel.Find(x => x.Id.Equals(id));
            _employeeViewModel.Remove(employee);

            return RedirectToAction("List");
        }
    }
}