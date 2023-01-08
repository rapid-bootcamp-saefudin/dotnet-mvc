using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetMVC.Models;


namespace DotnetMVC.Controllers
{
    public class ProjectController : Controller
    {
        private static List<ProjectViewModel> _projectViewModel = new List<ProjectViewModel>()
            {
                new ProjectViewModel(
                    1,
                    "Email Gateway",
                    "Done"
                ),
                new ProjectViewModel(
                    2,
                    "Marketplace",
                    "Testing"
                ),
                new ProjectViewModel(
                    3,
                    "Employee Management System",
                    "Review"
                ),
                new ProjectViewModel(
                    4,
                    "Inventory Management System",
                    "Doing"
                ),
                new ProjectViewModel(
                    5,
                    "Payment System",
                    "Done"
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

            return View(_projectViewModel);
        }

        [HttpPost]
        public IActionResult Save([Bind("Id, ProjectName, Status")] ProjectViewModel project)
        {
            _projectViewModel.Add(project);
            return Redirect("List");
        }

        public IActionResult Edit(int? id)
        {
            ProjectViewModel project = _projectViewModel.Find(x => x.Id.Equals(id));
            return View(project);
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id, ProjectName, Status")] ProjectViewModel project)
        {
            ProjectViewModel projectOld = _projectViewModel.Find(x => x.Id.Equals(id));
            _projectViewModel.Remove(projectOld);

            _projectViewModel.Add(project);
            return Redirect("List");
        }


        public IActionResult Details(int id)
        {
            ProjectViewModel project = (
                from p in _projectViewModel
                where p.Id.Equals(id)
                select p).SingleOrDefault(new ProjectViewModel());
            return View(project);
        }

        public IActionResult Delete(int? id)
        {
            ProjectViewModel project = _projectViewModel.Find(x => x.Id.Equals(id));
            _projectViewModel.Remove(project);

            return RedirectToAction("List");
        }
    }
}